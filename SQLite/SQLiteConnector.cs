using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace SQLite
{
    public class SQLiteConnector : IDisposable
    {
        private SQLiteConnection _connection;
        private SQLiteTransaction _transaction;

        public SQLiteConnection Connection
        {
            get
            {
                //Open connection if it is broken or closed.
                if (_connection.State == ConnectionState.Broken
                || _connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                //Return ready connection.
                return _connection;
            }
        }

        public ConnectionState ConnectionState
        {
            get => _connection.State;
        }

        public string ConnectionString
        {
            get => _connection.ConnectionString;
            set => _connection.ConnectionString = value;
        }

        public SQLiteConnector(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        private void BreakConnection()
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }

        public void BeginTransaction()
        {
            _transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            PrepareSQLiteCommand(query, parameters).ExecuteNonQuery();
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            return PrepareSQLiteCommand(query, parameters).ExecuteScalar();
        }

        public SQLiteDataReader ExecuteReader(string query, Dictionary<string, object> parameters = null)
        {
            return PrepareSQLiteCommand(query, parameters).ExecuteReader();
        }

        public List<Dictionary<string, object>> ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            List<Dictionary<string, object>> output = new List<Dictionary<string, object>>();

            using (SQLiteDataReader reader = ExecuteReader(query, parameters))
            {
                Dictionary<string, int> columns = new Dictionary<string, int>();

                for (int column = 0; column < reader.FieldCount; column++)
                {
                    columns.Add(reader.GetName(column), column);
                }

                while (reader.Read())
                {
                    Dictionary<string, object> record = new Dictionary<string, object>();

                    foreach (KeyValuePair<string, int> column in columns)
                    {
                        record.Add(column.Key, reader.GetValue(column.Value));
                    }

                    output.Add(record);
                }
            }

            return output;
        }

        public List<object> GetColumnValues(List<Dictionary<string, object>> resultSet, string columnName)
        {
            List<object> columnValues = new List<object>();

            if (resultSet[0].ContainsKey(columnName))
            {
                resultSet.ForEach(result => columnValues.Add(result[columnName]));
            }

            return columnValues;
        }

        public List<object> GetColumnValues(List<Dictionary<string, object>> resultSet, int columnIndex)
        {
            string[] columnNames = new string[resultSet[0].Count];

            resultSet[0].Keys.CopyTo(columnNames, 0);

            return GetColumnValues(resultSet, columnNames[columnIndex]);
        }

        private SQLiteCommand PrepareSQLiteCommand(string query, Dictionary<string, object> parameters = null)
        {
            SQLiteConnection conn = Connection;
            SQLiteCommand SQLiteCommand = new SQLiteCommand(query, conn);

            if (_transaction != null)
            {
                SQLiteCommand.Transaction = _transaction;
            }

            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    SQLiteCommand.Parameters.AddWithValue(keyValuePair.Key, keyValuePair.Value);
                }
            }

            return SQLiteCommand;
        }

        #region "IDisposable"
        private bool isDisposed = false;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    //Release resources
                    RollbackTransaction();
                    BreakConnection();
                }
            }

            this.isDisposed = true;
        }
        ~SQLiteConnector()
        {
            this.Dispose(false);
        }
        #endregion
    }
}

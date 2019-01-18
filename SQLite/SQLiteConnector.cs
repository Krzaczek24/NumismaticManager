using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

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


        public SQLiteConnector(string databaseFilePath)
        {
            //Prepare connection.
            _connection = new SQLiteConnection($"Data Source={databaseFilePath}");

            //Check if database file exists.
            if (!File.Exists(databaseFilePath)) CreateDatabase();
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

        private void CreateDatabase()
        {
            BeginTransaction();

            try
            {
                //Tables creation.
                ExecuteNonQuery("CREATE TABLE Coin (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Value INTEGER NOT NULL, Diameter REAL, Fineness TEXT, Weight REAL, Edition INTEGER, Emission TEXT, Stamp TEXT, UNIQUE (Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) ON CONFLICT IGNORE);");
                ExecuteNonQuery("CREATE TABLE Collection (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Id_coin INTEGER NOT NULL REFERENCES Coin (Id), Amount INTEGER NOT NULL DEFAULT 0);");
                ExecuteNonQuery("CREATE TABLE EventHistory (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Id_collection INTEGER NOT NULL REFERENCES Collection (Id), Date TEXT NOT NULL, ChangedFrom INTEGER NOT NULL, ChangedTo INTEGER NOT NULL, Difference INTEGER NOT NULL);");
                ExecuteNonQuery("CREATE TABLE ErrorHistory (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Date TEXT NOT NULL, Class TEXT NOT NULL, Function TEXT NOT NULL, Message TEXT NOT NULL);");

                //Triggers creation.
                ExecuteNonQuery("CREATE TRIGGER AfterCollectionInsert AFTER INSERT ON Collection FOR EACH ROW BEGIN INSERT INTO EventHistory(Id_collection, ChangedFrom, ChangedTo, Difference) VALUES(NEW.Id, 0, NEW.Amount, NEW.Amount); END;");
                ExecuteNonQuery("CREATE TRIGGER AfterCollectionUpdate AFTER UPDATE ON Collection FOR EACH ROW BEGIN INSERT INTO EventHistory(Id_collection, ChangedFrom, ChangedTo, Difference) VALUES(NEW.Id, OLD.Amount, NEW.Amount, CAST(NEW.Amount AS SIGNED) - CAST(OLD.Amount AS SIGNED)); END;");

                CommitTransaction();
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw new InvalidOperationException();
            }
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

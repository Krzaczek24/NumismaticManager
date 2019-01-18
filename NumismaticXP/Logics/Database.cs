using NumismaticXP.Forms;
using NumismaticXP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace NumismaticXP.Logics
{
    static class Database
    {
        public enum CollectionType { All, Owned, Redundant, Missing }

        public static DataTable DownloadCoins(CollectionType type, string valuesFilter)
        {
            bool contentsUser = type == CollectionType.Owned || type == CollectionType.Redundant;

            string query =
                $"SELECT Coin.Id AS CoinID, Name, Value, Edition, Emission, {(contentsUser ? null : "IFNULL(Amount, 0) AS")} Amount " +
                $"FROM {(contentsUser ? "Collection LEFT JOIN Coin" : "Coin LEFT JOIN Collection")} ON Coin.Id = Collection.Id_coin ";

            switch (type)
            {
                case CollectionType.All:
                    query += $"WHERE TRUE ";
                    break;
                case CollectionType.Owned:
                    query += $"WHERE Amount > 0 ";
                    break;
                case CollectionType.Redundant:
                    query += $"WHERE Amount > 1 ";
                    break;
                case CollectionType.Missing:
                    query += "WHERE (Amount IS NULL OR Amount = 0) ";
                    break;
            }

            if (valuesFilter.Length > 0) query += $"AND Value IN ({valuesFilter});";

            try
            {
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter myadapter = new SQLiteDataAdapter(query, Main.Connector.Connection);
                myadapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "UserCollection", "DownloadCoins");
                throw ex;
            }
        }

        public static List<Coin> DownloadAllCoins()
        {
            List<Coin> coins = new List<Coin>();

            string query = "SELECT Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp FROM Coin;";

            try
            {
                using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        coins.Add(new Coin()
                        {
                            Name = reader.GetString(0),
                            Value = reader.GetInt32(1),
                            Diameter = reader.GetDecimal(2),
                            Fineness = reader.GetString(3),
                            Weight = reader.GetDecimal(4),
                            Edition = reader.GetInt32(5),
                            Emission = reader.GetDateTime(6),
                            Stamp = reader.GetString(7)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "DownloadAllCoins");
                throw ex;
            }

            return coins;
        }

        public static void Insert(List<Coin> coins)
        {
            try
            {
                Main.Connector.BeginTransaction();
                coins.ForEach(coin => Insert(coin));
                Main.Connector.CommitTransaction();
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "Insert");
                throw ex;
            }
        }

        public static void Insert(Coin coin)
        {
            string query = "INSERT INTO Coin(Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) " +
                            "VALUES(@name, @value, @diameter, @fineness, @weight, @edition, @emission, @stamp);";

            try
            {
                Main.Connector.ExecuteNonQuery(query, coin.ToDictionary());
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "Insert");
                throw ex;
            }
        }

        public static List<int> GetCoinValues()
        {
            List<int> output = new List<int>();

            string query = "SELECT DISTINCT Value FROM Coin ORDER BY Value DESC;";

            try
            {
                using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetCoinValues");
                throw ex;
            }

            return output;
        }

        public static int GetCoinsCount()
        {
            string query = "SELECT COUNT(*) FROM Coin;";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetCoinsCount");
                throw ex;
            }
        }

        #region "User methods"
        public static int GetUserUniqueCoins()
        {
            string query = "SELECT COUNT(*) FROM Collection WHERE Amount > 0;";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserUniqueCoins");
                throw ex;
            }
        }

        public static int GetUserTotalCoins()
        {
            string query = "SELECT SUM(Amount) FROM Collection;";

            try
            {
                object result = Main.Connector.ExecuteScalar(query);
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalCoins");
                throw ex;
            }
        }

        public static decimal GetUserTotalWeight()
        {
            string query = "SELECT SUM(Amount * Weight) FROM Collection LEFT JOIN Coin ON Coin.Id = Collection.Id_coin;";

            try
            {
                object result = Main.Connector.ExecuteScalar(query);
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalWeight");
                throw ex;
            }
        }

        public static decimal GetUserTotalValue()
        {
            string query = "SELECT SUM(Amount * Value) FROM Collection LEFT JOIN Coin ON Coin.Id = Collection.Id_coin;";

            try
            {
                object result = Main.Connector.ExecuteScalar(query);
                return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalValue");
                throw ex;
            }
        }
        #endregion

        #region "Events & Errors"
        public static void AddError(string message, string className, string functionName, string comment = null)
        {
            string query = "INSERT INTO ErrorHistory(Class, Function, Message, Comment) VALUES(@class, @func, @msg, @comm)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@class", className },
                { "@func", functionName },
                { "@msg", message },
                { "@comm", comment }
            };

            try
            {
                Main.Connector.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu błedu do bazy!", "Błąd krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Error> GetErrors()
        {
            List<Error> errors = new List<Error>();

            string query = "SELECT Date, Class, Function, Message, Comment FROM ErrorHistory";

            try
            {
                using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        errors.Add(new Error()
                        {
                            Date = reader.GetDateTime(0),
                            ClassName = reader.GetString(1),
                            FunctionName = reader.GetString(2),
                            Message = reader.GetString(3),
                            Comment = reader.GetString(4)
                        });
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd podczas pobierania błędów z bazy!", "Błąd krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return errors;
        }

        //private static void AddEvent(uint collectionId, bool incremented)
        //{
        //    string query = "INSERT INTO EventHistory(Id_collection, Incremented) VALUES(@id, @incr)";

        //    Dictionary<string, object> parameters = new Dictionary<string, object>()
        //    {
        //        { "@id", collectionId },
        //        { "@incr", incremented }
        //    };

        //    try
        //    {
        //        Main.Connector.ExecuteNonQuery(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        AddError(ex.Message, "Database", "AddEvent");
        //    }
        //}

        public static void WipeUserCollection()
        {
            try
            {
                Main.Connector.ExecuteNonQuery($"UPDATE Collection SET Amount = 0;");
                MessageBox.Show("Pomyślnie usunięto kolekcję.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "WipeUserCollection");
                MessageBox.Show("Wystąpił błąd podczas usuwania kolekcji!\nOperacja została wycofana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void WipeDatabase()
        {
            try
            {
                Main.Connector.BeginTransaction();
                Main.Connector.ExecuteNonQuery("DELETE FROM EventHistory;");
                Main.Connector.ExecuteNonQuery("DELETE FROM Collection;");
                Main.Connector.ExecuteNonQuery("DELETE FROM Coin;");
                Main.Connector.CommitTransaction();
                MessageBox.Show("Pomyślnie usunięto wszystkie dane z bazy.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Main.Connector.RollbackTransaction();
                AddError(ex.Message, "Database", "WipeDatabase");
                MessageBox.Show("Wystąpił błąd podczas usuwania danych z bazy!\nOperacja została wycofana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

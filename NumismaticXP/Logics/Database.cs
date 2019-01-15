using MySql.Data.MySqlClient;
using Numismatic.Forms;
using Numismatic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Numismatic.Logics
{
    static class Database
    {
        public static class UserCollection
        {
            private enum CollectionType { All, Owned, Redundant, Missing }

            public static DataTable AllCoins { get => DownloadCoins(CollectionType.All); }

            public static DataTable OwnedCoins { get => DownloadCoins(CollectionType.Owned); }

            public static DataTable RedundantCoins { get => DownloadCoins(CollectionType.Redundant); }

            public static DataTable MissingCoins { get => DownloadCoins(CollectionType.Missing); }

            private static DataTable DownloadCoins(CollectionType type)
            {
                bool contentsUser = type == CollectionType.Owned || type == CollectionType.Redundant;

                List<uint> filter = Main.LoggedUser.ShowCoins;

                string query =
                    $"SELECT Coin.Id AS CoinID, Name, Value, Edition, Emission, {(contentsUser ? null : "IFNULL(Amount, 0) AS")} Amount " +
                    $"FROM Collection {(contentsUser ? "LEFT" : "RIGHT")} JOIN Coin ON Coin.Id = Collection.Id_coin ";

                switch (type)
                {
                    case CollectionType.All:
                        query += $"WHERE TRUE ";
                        break;
                    case CollectionType.Owned:
                        query += $"WHERE Collection.Id_user = {Main.LoggedUser.Id} AND Amount > 0 ";
                        break;
                    case CollectionType.Redundant:
                        query += $"WHERE Collection.Id_user = {Main.LoggedUser.Id} AND Amount > 1 ";
                        break;
                    case CollectionType.Missing:
                        query += "WHERE (Amount IS NULL OR Amount = 0) ";
                        break;
                }

                if (filter.Count > 0) query += $"AND Value IN ({string.Join(",", Main.LoggedUser.ShowCoins)});";

                try
                {
                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter myadapter = new MySqlDataAdapter(query, Main.Servant.Connection);
                    myadapter.Fill(dataSet);
                    return dataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    AddError(ex.Message, "UserCollection", "DownloadCoins");
                    throw ex;
                }
            }
        }

        public static List<Coin> DownloadAllCoins()
        {
            List<Coin> coins = new List<Coin>();

            string query = "SELECT Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp FROM Coin;";

            try
            {
                using (MySqlDataReader reader = Main.Servant.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        coins.Add(new Coin()
                        {
                            Name = reader.GetString("Name"),
                            Value = reader.GetUInt32("Value"),
                            Diameter = reader.GetDecimal("Diameter"),
                            Fineness = reader.GetString("Fineness"),
                            Weight = reader.GetDecimal("Weight"),
                            Edition = reader.GetUInt32("Edition"),
                            Emission = reader.GetDateTime("Emission"),
                            Stamp = reader.GetString("Stamp")
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
                Main.Servant.BeginTransaction();
                coins.ForEach(coin => Insert(coin));
                Main.Servant.CommitTransaction();
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
                Main.Servant.ExecuteNonQuery(query, coin.ToDictionary());
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "Insert");
                throw ex;
            }
        }

        public static List<uint> GetCoinValues()
        {
            List<uint> output = new List<uint>();

            string query = "SELECT DISTINCT Value FROM Coin ORDER BY Value DESC;";

            try
            {
                using (MySqlDataReader reader = Main.Servant.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetUInt32("Value"));
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

        public static void SaveCoinsFilter(List<uint> filter)
        {
            string query = "UPDATE User SET Show_coins = @filter WHERE Id = @usr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id },
                { "@filter", string.Join(";", filter) }
            };

            try
            {
                Main.Servant.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "SaveCoinsFilter");
                throw ex;
            }
        }

        #region "User methods"
        public static uint GetUserUniqueCoins()
        {
            string query = "SELECT COUNT(*) FROM Collection WHERE Id_user = @usr AND Amount > 0";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id }
            };

            try
            {
                return Convert.ToUInt32(Main.Servant.ExecuteScalar(query, parameters));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserUniqueCoins");
                throw ex;
            }
        }

        public static uint GetUserTotalCoins()
        {
            string query = "SELECT SUM(Amount) FROM Collection WHERE Id_user = @usr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id }
            };

            try
            {
                return Convert.ToUInt32(Main.Servant.ExecuteScalar(query, parameters));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalCoins");
                throw ex;
            }
        }

        public static decimal GetUserTotalWeight()
        {
            string query = "SELECT SUM(Amount * Weight) FROM Collection LEFT JOIN Coin ON Coin.Id = Collection.Id_coin WHERE Id_user = @usr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id }
            };

            try
            {
                return Convert.ToDecimal(Main.Servant.ExecuteScalar(query, parameters));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalWeight");
                throw ex;
            }
        }

        public static decimal GetUserTotalValue()
        {
            string query = "SELECT SUM(Amount * Value) FROM Collection LEFT JOIN Coin ON Coin.Id = Collection.Id_coin WHERE Id_user = @usr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id }
            };

            try
            {
                return Convert.ToDecimal(Main.Servant.ExecuteScalar(query, parameters));
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserTotalValue");
                throw ex;
            }
        }

        public static List<uint> GetUserCoinFilter()
        {
            List<uint> output = new List<uint>();

            string query = "SELECT Show_coins FROM User WHERE Id = @usr";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id }
            };

            string[] values;
            try
            {
                values = Main.Servant.ExecuteScalar(query, parameters).ToString().Split(';');
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database", "GetUserCoinFilter");
                throw ex;
            }

            if (values[0].Length > 0)
            {
                foreach (string value in values)
                {
                    output.Add(uint.Parse(value));
                }
            }

            return output;
        }
        #endregion

        #region "Events & Errors"
        public static void AddError(string message, string className, string functionName, string comment = null)
        {
            string query = "INSERT INTO ErrorHistory(Id_user, Class, Function, Message, Comment) VALUES(@usr, @class, @func, @msg, @comm)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@usr", Main.LoggedUser.Id },
                { "@class", className },
                { "@func", functionName },
                { "@msg", message },
                { "@comm", comment }
            };

            try
            {
                Main.Servant.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                MessageBox.Show("Wystąpił błąd podczas zapisu błedu do bazy!", "Błąd krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Error> GetErrors()
        {
            List<Error> errors = new List<Error>();

            string query = "SELECT Id_user, Date, Class, Function, Message, Comment FROM ErrorHistory";

            try
            {
                using (MySqlDataReader reader = Main.Servant.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        errors.Add(new Error()
                        {
                            UserId = reader.GetUInt32("Id_user"),
                            Date = reader.GetDateTime("Date"),
                            ClassName = reader.GetString("Class"),
                            FunctionName = reader.GetString("Function"),
                            Message = reader.GetString("Message"),
                            Comment = reader.GetString("Comment")
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

        public static void AddEvent(uint collectionId, bool incremented)
        {
            string query = "INSERT INTO EventHistory(Id_collection, Incremented) VALUES(@id, @incr)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@id", collectionId },
                { "@incr", incremented }
            };

            try
            {
                Main.Servant.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                AddError(Main.LoggedUser.Id.ToString(), ex.Message, "Database", "AddEvent");
            }
        }

        public static void FullClear()
        {
            try
            {
                Main.Servant.ExecuteNonQuery("DELETE FROM Collection; DELETE FROM Coin;");
            }
            catch (Exception ex)
            {
                AddError(Main.LoggedUser.Id.ToString(), ex.Message, "Database", "FullClear");

            }
        }
        #endregion
    }
}

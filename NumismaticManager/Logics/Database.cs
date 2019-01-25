using NumismaticManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace NumismaticManager.Logics
{
    static class Database
    {
        public enum CollectionType { All, Owned, Redundant, Missing }

        public static DataTable DownloadCoins(CollectionType type, string valuesFilter)
        {
            bool contentsUser = type == CollectionType.Owned || type == CollectionType.Redundant;

            string query =
                $"SELECT Id, Name, Value, Edition, Emission, IFNULL(Amount, 0) AS Amount FROM Coin ";

            switch (type)
            {
                case CollectionType.All:
                    query += $"WHERE TRUE ";
                    break;
                case CollectionType.Owned:
                    query += $"WHERE Amount > 0 ";
                    break;
                case CollectionType.Redundant:
                    query += $"WHERE Amount > {Properties.Settings.Default.Redundant} ";
                    break;
                case CollectionType.Missing:
                    query += "WHERE Amount = 0 ";
                    break;
            }

            if (valuesFilter.Length > 0) query += $"AND Value IN ({valuesFilter});";

            try
            {
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter myadapter = new SQLiteDataAdapter(query, Program.Connector.Connection);
                myadapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas pobierania monet z bazy danych.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "DownloadCoins(CollectionType type, string valuesFilter)");
                return null;
            }
        }

        public static List<Coin> DownloadAllCoins()
        {
            List<Coin> coins = new List<Coin>();

            string query = "SELECT Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp FROM Coin;";

            try
            {
                using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query))
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
                Program.ShowError("Wystąpił błąd podczas pobierania monet z bazy danych.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "DownloadAllCoins()");
            }

            return coins;
        }

        public static Coin GetCoin(int coinId)
        {
            string query = "SELECT Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp FROM Coin Where Id = @coin;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "coin", coinId }
            };

            using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query, parameters))
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    return new Coin
                    {
                        Name = reader.GetString(0),
                        Value = reader.GetInt32(1),
                        Diameter = reader.GetDecimal(2),
                        Fineness = reader.GetString(3),
                        Weight = reader.GetDecimal(4),
                        Edition = reader.GetInt32(5),
                        Emission = reader.GetDateTime(6),
                        Stamp = reader.GetString(7)
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Insert(Coin coin)
        {
            string query = "INSERT INTO Coin(Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) " +
                            "VALUES(@name, @value, @diameter, @fineness, @weight, @edition, @emission, @stamp);";

            try
            {
                Program.Connector.ExecuteNonQuery(query, coin.ToDictionary());
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "Insert(Coin coin)");
                throw;
            }
        }

        public static int GetNewestCoinId()
        {
            string query = "SELECT last_insert_rowid();";

            try
            {
                 return Convert.ToInt32(Program.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetNewestCoinId()");
                throw;
            }
        }

        public static void ChangeAmount(int coinId, bool increment)
        {
            char sign = increment ? '+' : '-';

            string query = $"UPDATE Coin SET Amount = Amount {sign} 1 WHERE Id = @coin;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "coin", coinId }
            };

            try
            {
                Program.Connector.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas próby zmiany ilości posiadanych monet.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "ChangeAmount(int coinId, bool increment)");
            } 
        }

        public static void ChangeAmount(int coinId, int amount)
        {
            string query = $"UPDATE Coin SET Amount = @amount WHERE Id = @coin;";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "coin", coinId },
                { "amount", amount }
            };

            try
            {
                if (amount < 0) throw new ArgumentOutOfRangeException();
                Program.Connector.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas próby zmiany ilości posiadanych monet.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "ChangeAmount(int coinId, bool increment)");
            }
        }

        public static List<int> GetCoinValues()
        {
            List<int> output = new List<int>();

            string query = "SELECT DISTINCT Value FROM Coin ORDER BY Value DESC;";

            try
            {
                using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetInt32(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas próby pobrania listy nominałów.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetCoinValues()");
            }

            return output;
        }

        public static List<string> GetFinenesses()
        {
            List<string> output = new List<string>();

            string query = "SELECT DISTINCT Fineness FROM Coin ORDER BY Fineness ASC;";

            try
            {
                using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas próby pobrania listy prób.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetFinenesses()");
            }

            return output;
        }

        public static List<string> GetStamps()
        {
            List<string> output = new List<string>();

            string query = "SELECT DISTINCT Stamp FROM Coin ORDER BY Stamp ASC;";

            try
            {
                using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas próby pobrania listy stempli.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetStamps()");
            }

            return output;
        }

        #region "User methods"
        public static int GetUserUniqueCoins()
        {
            string query = "SELECT COUNT(*) FROM Coin WHERE Amount > 0;";

            try
            {
                return Convert.ToInt32(Program.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserUniqueCoins()");
                return 0;
            }
        }

        public static int GetUserTotalCoins()
        {
            string query = "SELECT IFNULL(SUM(Amount), 0) FROM Coin;";

            try
            {
                return Convert.ToInt32(Program.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalCoins()");
                return 0;
            }
        }

        public static int GetUserTotalValue()
        {
            string query = "SELECT IFNULL(SUM(Amount * Value), 0) FROM Coin;";

            try
            {
                return Convert.ToInt32(Program.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystapił błąd podczas próby pobrania wartości monet.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalValue()");
                return 0;
            }
        }

        public static Dictionary<string, object> GetUserCoinsSummary()
        {
            Dictionary<string, object> output = null;

            int redundant = Properties.Settings.Default.Redundant;
            string firstPart = "SELECT COUNT(*), IFNULL(SUM(Amount), 0), IFNULL(SUM(Amount * Value), 0), IFNULL(SUM(Amount * Weight), 0) FROM Coin WHERE 1";
            string secondPart = "SELECT COUNT(*), IFNULL(SUM(Value), 0), IFNULL(SUM(Weight), 0) FROM Coin WHERE Amount > 0";
            string thirdPart = $"SELECT IFNULL(SUM(Amount - {redundant}), 0), IFNULL(SUM((Amount - {redundant}) * Value), 0), IFNULL(SUM((Amount - {redundant}) * Weight), 0) FROM Coin WHERE Amount > {redundant}";

            string filter = $" AND Value IN ({Properties.Settings.Default.CoinFilter})";

            if (Properties.Settings.Default.CoinFilter.Length > 0)
            {
                firstPart += filter;
                secondPart += filter;
                thirdPart += filter;
            }

            string query = $"SELECT * FROM ({firstPart}) JOIN ({secondPart}) JOIN ({thirdPart});";

            try
            {
                using (SQLiteDataReader reader = Program.Connector.ExecuteReader(query))
                {
                    reader.Read();

                    output = new Dictionary<string, object>
                    {
                        { "allCoins", reader.GetValue(0) },
                        { "ownedCoins", reader.GetValue(1) },
                        { "ownedCoinsValue", reader.GetValue(2) },
                        { "ownedCoinsWeight", reader.GetValue(3) },
                        { "uniqueCoins", reader.GetValue(4) },
                        { "uniqueCoinsValue", reader.GetValue(5) },
                        { "uniqueCoinsWeight", reader.GetValue(6) },
                        { "redundantCoins", reader.GetValue(7) },
                        { "redundantCoinsValue", reader.GetValue(8) },
                        { "redundantCoinsWeight", reader.GetValue(9) }
                    };
                }
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystapił błąd podczas próby pobrania danych do podsumowania.");
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserCoinsSummary()");
            }

            return output;
        }
        #endregion

        #region "Errors"
        public static void AddError(string message, string className, string functionName)
        {
            string query = "INSERT INTO ErrorHistory(Class, Function, Message) VALUES(@class, @func, @msg)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "class", className },
                { "func", functionName },
                { "msg", message }
            };

            try
            {
                Program.Connector.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                Program.ShowError("Wystąpił błąd podczas zapisu błedu do bazy!");
            }
        }

        public static DataTable GetErrors()
        {
            string query = "SELECT Date, Class, Function, Message FROM ErrorHistory ORDER BY Date DESC;";

            try
            {
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter myadapter = new SQLiteDataAdapter(query, Program.Connector.Connection);
                myadapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                Program.ShowError("Wystąpił błąd podczas pobierania błędów z bazy danych.");
                return null;
            }
        }
        #endregion

        #region "Database global operations"
        public static void Create()
        {
            Program.Connector.BeginTransaction();

            try
            {
                Program.Connector.ExecuteNonQuery("CREATE TABLE Coin (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Value INTEGER NOT NULL, Diameter REAL, Fineness TEXT, Weight REAL, Edition INTEGER, Emission DATE, Stamp TEXT, Amount INTEGER NOT NULL DEFAULT 0, UNIQUE (Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) ON CONFLICT IGNORE);");
                Program.Connector.ExecuteNonQuery("CREATE TABLE ErrorHistory (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, Class TEXT NOT NULL, Function TEXT NOT NULL, Message TEXT NOT NULL);");

                Program.Connector.CommitTransaction();
            }
            catch (Exception)
            {
                Program.Connector.RollbackTransaction();
                throw new InvalidOperationException();
            }
        }

        public static void WipeUserCollection()
        {
            try
            {
                Program.Connector.ExecuteNonQuery($"UPDATE Coin SET Amount = 0;");
                Program.ShowInformation("Pomyślnie usunięto kolekcję.");
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas usuwania kolekcji.\nOperacja została wycofana.");
                AddError(ex.Message, "Database.cs", "WipeUserCollection()");
            }
        }

        public static void WipeDatabase()
        {
            try
            {
                Program.Connector.BeginTransaction();
                Program.Connector.ExecuteNonQuery("DELETE FROM Coin;");
                Program.Connector.CommitTransaction();
                Program.ShowInformation("Pomyślnie usunięto wszystkie dane z bazy.");
            }
            catch (Exception ex)
            {
                Program.Connector.RollbackTransaction();
                Program.ShowError("Wystąpił błąd podczas usuwania danych z bazy!\nOperacja została wycofana.");
                AddError(ex.Message, "Database.cs", "WipeDatabase()");
            }
        }
        #endregion

        #region "Undo changes functionality"
        public static void SetCoinPreviousAmount(int coinId, int amount)
        {
            string query = "SELECT Name FROM Coin WHERE Id = @coin; UPDATE Coin SET Amount = @amount WHERE Id = @coin;";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "coin", coinId },
                { "amount", amount }
            };

            try
            {
                string coinName = Convert.ToString(Program.Connector.ExecuteScalar(query, parameters));
                Program.ShowInformation($"Pomyślnie cofnięto zmianę ilości monety:\n{coinName}");
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas zmiany liczby numizmatu.");
                AddError(ex.Message, "Database.cs", "SetCoinPreviousAmount(int coinId, int amount)");
            }
        }

        public static void RemoveCoin(int coinId)
        {
            string query = "SELECT Name FROM Coin WHERE Id = @coin; REMOVE Coin WHERE Id = @coin;";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "coin", coinId }
            };

            try
            {
                string coinName = Convert.ToString(Program.Connector.ExecuteScalar(query, parameters));
                Program.ShowInformation($"Pomyślnie usunięto numizmat:\n{coinName}");
            }
            catch (Exception ex)
            {
                Program.ShowError("Wystąpił błąd podczas usuwania numizmatu.");
                AddError(ex.Message, "Database.cs", "RemoveCoin(int coinId)");
            }
        }
        #endregion
    }
}

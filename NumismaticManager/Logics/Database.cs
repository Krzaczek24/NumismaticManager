using NumismaticManager.Forms;
using NumismaticManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

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
                    query += $"WHERE Amount > 1 ";
                    break;
                case CollectionType.Missing:
                    query += "WHERE Amount = 0 ";
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
                AddError($"{ex.Message}\n{query}", "Database.cs", "DownloadCoins(CollectionType type, string valuesFilter)");
                Main.ShowError("Wystąpił błąd podczas pobierania monet z bazy danych.");
                return null;
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
                AddError($"{ex.Message}\n{query}", "Database.cs", "DownloadAllCoins()");
                Main.ShowError("Wystąpił błąd podczas pobierania monet z bazy danych.");
            }

            return coins;
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
                AddError($"{ex.Message}\n{query}", "Database.cs", "Insert(Coin coin)");
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
                Main.Connector.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "ChangeAmount(int coinId, bool increment)");
                Main.ShowError("Wystąpił błąd podczas próby zmiany ilości posiadanych monet.");
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
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetCoinValues()");
                Main.ShowError("Wystąpił błąd podczas próby pobrania listy nominałów.");
            }

            return output;
        }

        public static int GetCoinsCount(string filter)
        {
            string query = "SELECT COUNT(*) FROM Coin";

            if (filter.Length > 0)
            {
                query += $" WHERE Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetCoinsCount(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                return 0;
            }
        }

        public static List<string> GetFinenesses()
        {
            List<string> output = new List<string>();

            string query = "SELECT DISTINCT Fineness FROM Coin ORDER BY Fineness ASC;";

            try
            {
                using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetFinenesses()");
                Main.ShowError("Wystąpił błąd podczas próby pobrania listy prób.");
            }

            return output;
        }

        public static List<string> GetStamps()
        {
            List<string> output = new List<string>();

            string query = "SELECT DISTINCT Stamp FROM Coin ORDER BY Stamp ASC;";

            try
            {
                using (SQLiteDataReader reader = Main.Connector.ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        output.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetStamps()");
                Main.ShowError("Wystąpił błąd podczas próby pobrania listy stempli.");
            }

            return output;
        }

        #region "User methods"
        public static int GetUserUniqueCoins()
        {
            string query = "SELECT COUNT(*) FROM Coin WHERE Amount > 0;";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserUniqueCoins()");
                Main.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                return 0;
            }
        }

        public static int GetUserUniqueCoins(string filter)
        {
            string query = "SELECT COUNT(*) FROM Coin WHERE Amount > 0";

            if (filter.Length > 0)
            {
                query += $" AND Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserUniqueCoins(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                return 0;
            }
        }

        public static int GetUserUniqueValue(string filter)
        {
            string query = "SELECT IFNULL(SUM(Value), 0) FROM Coin WHERE Amount > 0";

            if (filter.Length > 0)
            {
                query += $" AND Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserUniqueValue(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania wartości monet.");
                return 0;
            }
        }

        public static decimal GetUserUniqueWeight(string filter)
        {
            string query = "SELECT IFNULL(SUM(Weight), 0) FROM Coin WHERE Amount > 0";

            if (filter.Length > 0)
            {
                query += $" AND Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToDecimal(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserUniqueWeight(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania wagi monet.");
                return 0;
            }
        }

        public static int GetUserTotalCoins()
        {
            string query = "SELECT IFNULL(SUM(Amount), 0) FROM Coin;";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalCoins()");
                Main.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                return 0;
            }
        }

        public static int GetUserTotalCoins(string filter)
        {
            string query = "SELECT IFNULL(SUM(Amount), 0) FROM Coin";

            if (filter.Length > 0)
            {
                query += $" WHERE Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalCoins(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania liczby monet.");
                return 0;
            }
        }

        public static int GetUserTotalValue()
        {
            string query = "SELECT IFNULL(SUM(Amount * Value), 0) FROM Coin;";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalValue()");
                Main.ShowError("Wystapił błąd podczas próby pobrania wartości monet.");
                return 0;
            }
        }

        public static int GetUserTotalValue(string filter)
        {
            string query = "SELECT IFNULL(SUM(Amount * Value), 0) FROM Coin";

            if (filter.Length > 0)
            {
                query += $" WHERE Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToInt32(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalValue(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania wartości monet.");
                return 0;
            }
        }

        public static decimal GetUserTotalWeight(string filter)
        {
            string query = "SELECT IFNULL(SUM(Amount * Weight), 0) FROM Coin";

            if (filter.Length > 0)
            {
                query += $" WHERE Value IN ({filter})";
            }

            query += ";";

            try
            {
                return Convert.ToDecimal(Main.Connector.ExecuteScalar(query));
            }
            catch (Exception ex)
            {
                AddError($"{ex.Message}\n{query}", "Database.cs", "GetUserTotalWeight(string filter)");
                Main.ShowError("Wystapił błąd podczas próby pobrania wagi monet.");
                return 0;
            }
        }
        #endregion

        #region "Errors"
        public static void AddError(string message, string className, string functionName)
        {
            string query = "INSERT INTO ErrorHistory(Class, Function, Message) VALUES(@class, @func, @msg)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@class", className },
                { "@func", functionName },
                { "@msg", message }
            };

            try
            {
                Main.Connector.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                Main.ShowError("Wystąpił błąd podczas zapisu błedu do bazy!");
            }
        }

        public static DataTable GetErrors()
        {
            string query = "SELECT Date, Class, Function, Message FROM ErrorHistory ORDER BY Date DESC;";

            try
            {
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter myadapter = new SQLiteDataAdapter(query, Main.Connector.Connection);
                myadapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (Exception)
            {
                Main.ShowError("Wystąpił błąd podczas pobierania błędów z bazy danych.");
                return null;
            }
        }
        #endregion

        #region "Database global operations"
        public static void Create()
        {
            Main.Connector.BeginTransaction();

            try
            {
                Main.Connector.ExecuteNonQuery("CREATE TABLE Coin (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Value INTEGER NOT NULL, Diameter REAL, Fineness TEXT, Weight REAL, Edition INTEGER, Emission DATE, Stamp TEXT, Amount INTEGER NOT NULL DEFAULT 0, UNIQUE (Name, Value, Diameter, Fineness, Weight, Edition, Emission, Stamp) ON CONFLICT IGNORE);");
                Main.Connector.ExecuteNonQuery("CREATE TABLE ErrorHistory (Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, Class TEXT NOT NULL, Function TEXT NOT NULL, Message TEXT NOT NULL);");

                Main.Connector.CommitTransaction();
            }
            catch (Exception)
            {
                Main.Connector.RollbackTransaction();
                throw new InvalidOperationException();
            }
        }

        public static void Backup()
        {
            if (File.Exists(Main.DatabaseFile))
            {
                int lastSlashPosition = Main.DatabaseFile.LastIndexOf("\\");
                string destinationPath = $"{Main.DatabaseFile.Remove(lastSlashPosition)}\\backup\\{DateTime.Now.ToString().Replace(":", ".")}";

                if (!Directory.Exists(destinationPath)) Directory.CreateDirectory(destinationPath);

                File.Copy(Main.DatabaseFile, $"{destinationPath}\\{Properties.Settings.Default.DatabaseFile}");
            }
        }

        public static void WipeUserCollection()
        {
            try
            {
                Main.Connector.ExecuteNonQuery($"UPDATE Coin SET Amount = 0;");
                Main.ShowInformation("Pomyślnie usunięto kolekcję.");
            }
            catch (Exception ex)
            {
                AddError(ex.Message, "Database.cs", "WipeUserCollection()");
                Main.ShowError("Wystąpił błąd podczas usuwania kolekcji.\nOperacja została wycofana.");
            }
        }

        public static void WipeDatabase()
        {
            try
            {
                Main.Connector.BeginTransaction();
                Main.Connector.ExecuteNonQuery("DELETE FROM Coin;");
                Main.Connector.CommitTransaction();
                Main.ShowInformation("Pomyślnie usunięto wszystkie dane z bazy.");
            }
            catch (Exception ex)
            {
                Main.Connector.RollbackTransaction();
                AddError(ex.Message, "Database.cs", "WipeDatabase()");
                Main.ShowError("Wystąpił błąd podczas usuwania danych z bazy!\nOperacja została wycofana.");
            }
        }
        #endregion
    }
}

using MySql.Data.MySqlClient;
using Numismatic.Forms;
using Numismatic.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Numismatic.Models
{
    class User
    {
        private bool changed = true;
        private uint uniqueCoins = 0;
        private uint totalCoins = 0;
        private decimal totalWeight = 0;
        private decimal totalValue = 0;

        #region "Properties"
        [Browsable(false)]
        [DisplayName("Id")]
        public uint Id { get; }

        [DisplayName("Login")]
        public string Login { get; }

        [DisplayName("Ilość unikatowych monet")]
        public uint UniqueCoins { get { CheckUpToDate(); return uniqueCoins; } }

        [DisplayName("Ilość wszystkich monet")]
        public uint TotalCoins { get { CheckUpToDate(); return totalCoins; } }

        [DisplayName("Waga wszystkich monet")]
        public decimal TotalWeight { get { CheckUpToDate(); return totalWeight; } }

        [DisplayName("Wartość wszystkich monet")]
        public decimal TotalValue { get { CheckUpToDate(); return totalValue; } }

        [DisplayName("Data rejestracji")]
        public DateTime Registered { get; }

        [DisplayName("Ostatnie logowanie")]
        public DateTime LastLogin { get; }

        [DisplayName("Zarejestrowany od")]
        public TimeSpan RegisteredFor { get => DateTime.Now - Registered; }

        [DisplayName("Administrator")]
        public bool IsAdmin { get; }

        [DisplayName("Pokazuj nominały")]
        public List<uint> ShowCoins { get => Database.GetUserCoinFilter(); }
        #endregion

        #region "Constructors"
        public User(string login, string password, bool online = true)
        {
            if (online)
            {
                string query = "SELECT * FROM User WHERE BINARY Username = @usr AND Password = @pwd;";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@usr", login },
                    { "@pwd", Main.HashSHA256(password) }
                };

                using (MySqlDataReader mySqlDataReader = Main.Servant.ExecuteReader(query, parameters))
                {
                    if (mySqlDataReader.Read())
                    {
                        Id = mySqlDataReader.GetUInt32("Id");
                        Login = mySqlDataReader.GetString("Username");
                        Registered = mySqlDataReader.GetDateTime("Creation_date");
                        LastLogin = mySqlDataReader.GetDateTime("Last_login");
                        IsAdmin = mySqlDataReader.GetBoolean("Admin");
                    }
                    else throw new UnauthorizedAccessException("Invalid login or/and password!");
                }

                query = "UPDATE User SET Last_login = @now WHERE Id = @id;";

                parameters = new Dictionary<string, object>
                {
                    { "@id", Id },
                    { "@now", DateTime.Now }
                };

                Main.Servant.ExecuteNonQuery(query, parameters);
            }
            else
            {

            }
        }
        #endregion

        #region "Methods"
        private void CheckUpToDate()
        {
            if (changed)
            {
                changed = false;
                uniqueCoins = Database.GetUserUniqueCoins();
                totalCoins = Database.GetUserTotalCoins();
                totalWeight = Database.GetUserTotalWeight();
                totalValue = Database.GetUserTotalValue();
            }
        }

        public void Changed()
        {
            changed = true;
        }
        #endregion
    }
}

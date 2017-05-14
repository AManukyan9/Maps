using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace maps
{
    class Review
    {
        private string rev;
        private decimal rating;
        private string user;
        private string name;
        private string address;
        private static bool isFilling = false;

        public Review(string rev, decimal rating, string user, Building building, string sessionkey)
        {
            if (!User.SessionCheck(user, sessionkey) && !User.SessionCheck("admin", sessionkey) && !isFilling)
            {
                throw new KeyNotFoundException("User not logged in. (Invalid auth)");
            }
            if (rating != 1 && rating != 2 && rating != 3 && rating != 4 && rating != 5)
            {
                throw new ArgumentException("Can't give more than 5 stars.");
            }
            this.rev = rev;
            this.rating = rating;
            this.user = user;
            this.name = building.Name;
            this.address = building.Address.AddressName;

            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                MySqlCommand insert = new MySqlCommand(string.Format("INSERT INTO `reviewsdb`(`Cafe Name`, `Address`, `Review`, `Rating`, `User`) VALUES ('{0}','{1}','{2}','{3}','{4}')", this.name, this.address, this.rev, this.rating, this.user), conn);
                MySqlCommand delete = new MySqlCommand(string.Format("DELETE FROM `reviewsdb` WHERE User = '{0}' AND `Cafe Name` = '{1}' AND Address = '{2}'", this.user, this.name, this.address), conn);
                conn.Open();
                delete.ExecuteNonQuery();
                insert.ExecuteNonQuery();
                building.AddRating(this);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Fill()
        {
            isFilling = true;
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                MySqlCommand selectAll = new MySqlCommand("SELECT * FROM `reviewsdb` WHERE 1", conn);

                conn.Open();
                using (MySqlDataReader dr = selectAll.ExecuteReader())
                {
                    Console.WriteLine();
                    while (dr.Read())
                    {
                        new Review(dr.GetString(2), dr.GetDecimal(3), dr.GetString(4), Maps.ReturnCafe(dr.GetString(0), dr.GetString(1)), "");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            isFilling = false;
        }

        public override string ToString()
        {
            return "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄" + '\n' + "█ Review by: " + this.user + '\n' + "█ Points: " + this.rating + '\n' + "█ " + this.rev + '\n' + "█ " + this.name + " at " + this.address;
        }

        public string Rev { get { return this.rev; } }
        public decimal Rating { get { return this.rating; } }
        public string Username { get { return this.user; } }

    }
}

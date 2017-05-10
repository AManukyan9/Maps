using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace maps
{
    class Cafe : Building
    {
        private string name;
        private Address address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        public Cafe(string name, Address address, string website, string number, DateTime opening, DateTime closing)
            : base(name, address, website, number, opening, closing)
        {
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);

            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;
            this.opening = opening;
            this.closing = closing;
            MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO cafedb (`Name`, `Address`, `Long`, `Lat`, `Phone Number`, `Website`, `Opening Hour`, `Closing Hour`)" +
                "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                this.name, this.Address.AddressName, this.Address.Coord.Longitude, this.Address.Coord.Latitude, this.number, this.website, this.Opening.ToShortTimeString(), this.Closing.ToShortTimeString()), conn);
            try
            {
                conn.Open();

                MySqlCommand delete = new MySqlCommand(string.Format("DELETE FROM `cafedb` WHERE Address = '{0}'", this.Address.AddressName), conn);
                delete.ExecuteNonQuery();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            if (Maps.ContainsCafe(this))
            {
                throw new ArgumentException("Cafe already exists on this address");
            }
            else
            {
                Maps.AddCafe(this);
            }
            
        }

        public override string ToString()
        {
            if (this.name == "")
            {
                return "Cafe";
            }
            else
            {
                return "Cafe " + this.name;
            }
        }

        public string WorkingHours()
        {
            return this.opening.ToShortTimeString() + "-" + this.closing.ToShortTimeString();
        }

        public void OpenWebsite()
        {
            Process.Start(this.website);
        }
    }
}

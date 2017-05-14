using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Configuration;

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
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString; ;
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
                MySqlCommand select = new MySqlCommand(string.Format("SELECT `Name`, `Address` FROM `cafedb` WHERE Name = '{0}' AND Address = '{1}'", this.name, this.address.AddressName), conn);

                if (Maps.ContainsCafe(this.name, this.address.AddressName) && select.ExecuteScalar() != null)
                {
                    throw new ArgumentException("Cafe with same Name and Address already exists");
                }
                if (select.ExecuteScalar() == null)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
            if (!Maps.ContainsCafe(this.name, this.address.AddressName))
                Maps.AddCafe(this);
        }

        public override string ToString()
        {
            if (this.name == "")
            {
                return "Cafe";
            }
            else
            {
                return "Cafe " + this.name + " " + this.address.AddressName;
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

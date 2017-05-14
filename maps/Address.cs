using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace maps
{
    class Address
    {
        private string addressName;
        private GeoCoordinate coord;
        private static Dictionary<string, Address> streets = new Dictionary<string, Address>();
        private static bool isFilling = false;

        public Address(string addressName, GeoCoordinate coord)
        {
            this.addressName = addressName;
            this.coord = coord;
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                MySqlCommand insert = new MySqlCommand(string.Format("INSERT INTO `addressdb`(`Address Name`, `Lat`, `Long`) VALUES ('{0}','{1}','{2}')", this.addressName, this.coord.Latitude, this.coord.Longitude), conn);
                conn.Open();
                MySqlCommand select = new MySqlCommand(string.Format("SELECT `Address Name` FROM `addressdb` WHERE `Address Name` = '{0}'", this.addressName), conn);

                if (streets.ContainsKey(this.addressName) && select.ExecuteScalar() != null && !isFilling)
                    throw new ArgumentException("Address already exists");
                if (select.ExecuteScalar() == null)
                    insert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }           
            if (!streets.ContainsKey(addressName))
                streets.Add(this.addressName, this);
        }

        public static Address GetAddress(string address)
        {
            if (streets.ContainsKey(address))
            {
                return streets[address];
            }
            else
            {
                throw new ArgumentException("Address not found");
            }
        }        

        public static void Fill()
        {
            isFilling = true;
            string conString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                MySqlCommand selectAll = new MySqlCommand("SELECT * FROM `addressdb` WHERE 1", conn);

                conn.Open();
                using (MySqlDataReader dr = selectAll.ExecuteReader())
                {
                    Console.WriteLine();
                    while (dr.Read())
                    {
                        new Address(dr.GetString(0), new GeoCoordinate(dr.GetDouble(1), dr.GetDouble(2)));
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

        }   //use to dump database into programm

        public string AddressName { get { return this.addressName; } }
        public GeoCoordinate Coord { get { return this.coord; } }
    }
}

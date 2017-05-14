using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using MySql.Data.MySqlClient;


namespace maps
{
    class Maps
    {
        private static List<Cafe> cafes = new List<Cafe>();

        public static void Fill()
        {
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                MySqlCommand selectAll = new MySqlCommand("SELECT * FROM `cafedb` WHERE 1", conn);

                conn.Open();

                using (MySqlDataReader dr = selectAll.ExecuteReader())
                {                    
                    while (dr.Read())
                    {                       
                        GeoCoordinate gc = new GeoCoordinate(dr.GetDouble(3), dr.GetDouble(2));
                        Address ad = new Address(dr.GetString(1), gc);
                        Cafe cafe = new Cafe(dr.GetString(0), ad, dr.GetString(5), dr.GetString(4), DateTime.Parse(dr.GetString(6)), DateTime.Parse(dr.GetString(7)));
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
        }

        public static double Distance(Address a, Address b)
        {
            return a.Coord.GetDistanceTo(b.Coord);
        }

        public static List<Cafe> NearbyCafes(Address address, double radius)
        {
            List<Cafe> CCollection = new List<Cafe>();
            for (int i = 0; i < cafes.Count; i++)
            {
                if (Distance(address, (cafes[i]).Address) <= radius)
                {
                    CCollection.Add(cafes[i]);
                }
            }
            return CCollection;
        }

        public static List<Cafe> Search(string name, string address, double radius, decimal rating, DateTime opening, DateTime closing)
        {
            List<Cafe> returnCafe = new List<Cafe>();
            int[] filled = new int[cafes.Count];
            for (int i = 0; i < cafes.Count; i++)
            {
                filled[i] = (Distance(Address.GetAddress(address), cafes[i].Address) <= radius ? 1 : 0) + +(cafes[i].Name == name ? 1 : 0) + ((cafes[i]).Rating >= rating ? 1 : 0) + (CompareDateTime(cafes[i].Closing, closing) ? 0 : 1) + (CompareDateTime(cafes[i].Opening, opening) ? 1 : 0);
            }
            for (int i = 5; i >= 1; i--)
            {
                for (int j = 0; j < cafes.Count; j++)
                {
                    if (filled[j] == i)
                    {
                        returnCafe.Add(cafes[j]);
                    }
                }
            }
            return returnCafe;

        }

        public static List<Cafe> Search(string name, string address, double radius, decimal rating)
        {
            List<Cafe> returnCafe = new List<Cafe>();
            int[] filled = new int[cafes.Count];
            for (int i = 0; i < cafes.Count; i++)
            {
                filled[i] = (Distance(Address.GetAddress(address), cafes[i].Address) <= radius ? 1 : 0) + +(cafes[i].Name == name ? 1 : 0) + ((cafes[i]).Rating >= rating ? 1 : 0);
            }
            for (int i = 3; i >= 1; i--)
            {
                for (int j = 0; j < cafes.Count; j++)
                {
                    if (filled[j] == i)
                    {
                        returnCafe.Add(cafes[j]);
                    }
                }
            }
            return returnCafe;

        }

        private static bool CompareDateTime(DateTime a, DateTime b)
        {
            TimeSpan difference = (a - b);
            return (difference.TotalMilliseconds < 0);
        }

        public static void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        }

        public static bool ContainsCafe(string name, string address)
        {
            bool exists = false;
            for (int i = 0; i < cafes.Count; i++)
            {
                if (address == cafes[i].Address.AddressName && name == cafes[i].Name)
                    exists = true;
            }
            return exists;
        }

        public static Cafe ReturnCafe(string name, string address)
        {
            Cafe cf = null;
            for (int i = 0; i < cafes.Count; i++)
            {
                if (address.Equals(cafes[i].Address.AddressName) && name.Equals(cafes[i].Name))
                    cf = cafes[i];
            }
            return cf;
        }

    }

}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using MySql.Data.MySqlClient;


namespace maps
{
    class Program
    {
        static void Main(string[] args)
        {            
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            

            try
            {
                MySqlCommand selectAllCafe = new MySqlCommand("SELECT COUNT(*) FROM `cafedb`", conn);
                MySqlCommand selectAllUser = new MySqlCommand("SELECT COUNT(*) FROM `usersdb`", conn);

                conn.Open();
                
                if (Convert.ToInt32(selectAllCafe.ExecuteScalar()) > 0 || Convert.ToInt32(selectAllUser.ExecuteScalar()) > 0)
                {
                    Prompt();
                    Console.WriteLine("Y/N");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.KeyChar.Equals('y'))
                    {
                        Console.Write("\b \b");
                        User.FillDictionary();
                        Maps.Fill();
                    }
                    else
                    {
                        Console.WriteLine("\b \b");
                        Environment.Exit(1);
                    }
                }

                
                GeoCoordinate gc = new GeoCoordinate(10, 11);
                GeoCoordinate gc1 = new GeoCoordinate(10, 10);
                Address ad = new Address("Xanjyan", gc);
                Address ad1 = new Address("Xorenaci", gc1);
               // Cafe a = new maps.Cafe("Tashir", ad, "www.menu.am", "010633456", DateTime.Parse("10:30"), DateTime.Parse("22:30"));
               // Cafe b = new maps.Cafe("Tashir", ad1, "www.menu.am", "010633456", DateTime.Parse("10:30"), DateTime.Parse("22:30"));
                List<Cafe> searchResult = Maps.Search("Tashir", ad, 0, 0, DateTime.Parse("10:30:00"), DateTime.Parse("22:30:00"));
                foreach (Cafe item in searchResult)
                {
                    item.OpenWebsite();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }




        public static string PasswordInput()
        {
            string pass = "";

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return pass;
        }

        public static void Prompt()
        {
            Console.WriteLine("Data is available, would you like to load it?");
        }

        //public static void YesNoSelect()  
        //{
        //    Console.WriteLine("Y/N");
        //    ConsoleKeyInfo key = Console.ReadKey();
        //    if (key.KeyChar.Equals('y'))
        //    {
        //        Console.Write("\b \b");
        //        Console.WriteLine("you selected Yes");
        //    }
        //    else if (key.KeyChar.Equals('n'))
        //    {
        //        Console.Write("\b \b");
        //    }
        //    else
        //    {
        //        Console.Write("\b \b");
        //        Console.WriteLine("Select Yes or No");
        //    }
        //}
    }
}

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
            string sessionID = "";
            string currentUser = "";

            DumpDatabase();

            while (true)
            {
                string command;
                command = Console.ReadLine().Trim();
                switch (command)
                {
                    case "?":
                        Console.WriteLine(Help());
                        break;

                    case "Exit":
                        Environment.Exit(0);
                        break;

                    case "Clear":
                        Console.Clear();
                        break;

                    case "Info":
                        Console.WriteLine(Info());
                        break;

                    case "Create a Cafe":
                        try
                        {
                            Console.WriteLine("Please input a desired name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Please input a desired street name:");
                            string street = Console.ReadLine();
                            Console.WriteLine("Please input the coordinates (Lat, Long accordingly):");
                            double lat = Convert.ToDouble(Console.ReadLine());
                            double longitude = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please input the website:");
                            string website = Console.ReadLine();
                            Console.WriteLine("Please input the phone number:");
                            string number = Console.ReadLine();
                            Console.WriteLine("Please input the opening time and closing time accordingly:");
                            DateTime opening = DateTime.Parse(Console.ReadLine());
                            DateTime closing = DateTime.Parse(Console.ReadLine());
                            GeoCoordinate geo = new GeoCoordinate(lat, longitude);
                            Address adr = new Address(street, geo);
                            Cafe cafe = new Cafe(name, adr, website, number, opening, closing);
                        }
                        catch
                        {
                            Console.WriteLine("Cafe with same Name and Address already exists!");
                        }
                        break;

                    case "Find Cafe": //Areg make me

                        break;

                    case "Register":
                        try
                        {
                            Console.WriteLine("Please input a desired username:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Please input a password:");
                            string password = PasswordInput();
                            User.Register(username, password);
                            Console.WriteLine("Successfully register user: " + username);
                        }
                        catch
                        {
                            Console.WriteLine("Username already exists!");
                        }
                        break;

                    case "Login":
                        try
                        {
                            Console.WriteLine("Please input your username:");
                            string usernameLog = Console.ReadLine();
                            Console.WriteLine("Please input your password:");
                            string passwordLog = PasswordInput();
                            sessionID = User.Auth(usernameLog, passwordLog);
                            if (!sessionID.Equals(null))
                            {
                                currentUser = usernameLog;
                                Console.WriteLine("Logged in successfully");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Wrong Login!");
                        }
                        break;



                    case "write session id":
                        if (!sessionID.Equals(null))
                        {
                            Console.WriteLine(sessionID);
                        }
                        else
                        {
                            Console.WriteLine("No current session!");
                        }
                        break;

                    case "check session":
                        if (User.SessionCheck(currentUser, sessionID))
                        {
                            Console.WriteLine(currentUser + " is logged in!");
                        }
                        else
                        {
                            Console.WriteLine("No current session!");
                        }
                        break;

                    default:
                        Console.WriteLine(ErrorMessage());
                        break;
                }
            }
        }

        public static void DumpDatabase()
        {
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);


            try
            {
                MySqlCommand selectAllCafe = new MySqlCommand("SELECT COUNT(*) FROM `cafedb`", conn);
                MySqlCommand selectAllUser = new MySqlCommand("SELECT COUNT(*) FROM `usersdb`", conn);
                MySqlCommand deleteDataCafe = new MySqlCommand("DELETE FROM `cafedb` WHERE 1", conn);
                MySqlCommand deleteDataUser = new MySqlCommand("DELETE FROM `usersdb` WHERE 1", conn);
                MySqlCommand deleteDataReview = new MySqlCommand("DELETE FROM `reviewsdb` WHERE 1", conn);
                MySqlCommand addAdmin = new MySqlCommand("INSERT INTO `usersdb`(`User`,`Password`) VALUES ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')", conn);

                conn.Open();

                if (Convert.ToInt32(selectAllCafe.ExecuteScalar()) > 0 || Convert.ToInt32(selectAllUser.ExecuteScalar()) > 0)
                {
                    Prompt();
                    Console.WriteLine("Y/N");
                    ConsoleKeyInfo key = Console.ReadKey();

                    while (key.KeyChar != 'y' || key.KeyChar != 'n')
                    {
                        Console.Write("\b \b");
                        
                        Console.Write("\b \b");
                        if (key.KeyChar.Equals('y'))
                        {
                            Console.Write("\b \b");
                            User.FillDictionary();
                            Maps.Fill();
                            Review.Fill();
                            Console.WriteLine("Database loaded successfully");
                            break;
                        }
                        else if (key.KeyChar.Equals('n'))
                        {
                            Console.Write("\b \b");
                            deleteDataCafe.ExecuteNonQuery();
                            deleteDataUser.ExecuteNonQuery();
                            deleteDataReview.ExecuteNonQuery();
                            addAdmin.ExecuteNonQuery();
                            Console.WriteLine("Database cleared");
                            break;
                        }
                        key = Console.ReadKey();
                    }

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

        public static string Help() //fix later
        {
            return null;
        }

        public static string Info() //fix later
        {
            return null;
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
            Console.WriteLine();
            return pass;
        }

        public static void Prompt()
        {
            Console.WriteLine("Data is available, would you like to load it? Selecting NO will result in a DELETED database");
        }

        public static string ErrorMessage()
        {
            return "Incorrect command, type ? for list of commands.";
        }
       
    }
}

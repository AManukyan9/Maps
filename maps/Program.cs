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
        //password for "Guest" is guest ;)
        static void Main(string[] args)
        {
            string sessionID = "";
            string currentUser = "";
            Cafe currentCafe = null;
            List<Cafe> currentCafes = new List<Cafe>();

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

                    case "Create Cafe":
                        try
                        {
                            CreateCafe();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("Creation failed, reason: " + e.Message);
                        }
                        break;

                    case "Search Cafes":
                        try
                        {
                            currentCafes = SearchCafes();
                            int i = 1;
                            foreach (Cafe item in currentCafes)
                            {
                                Console.WriteLine(i + ". " + item.ToString());
                                i++;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Cafe does not exist");
                        }
                        break;

                    case "Choose Cafe":
                        try
                        {
                            Console.WriteLine("Please select the number of the cafe from your search:");
                            int num = Convert.ToInt32(Console.ReadLine());
                            currentCafe = currentCafes[num - 1];
                            Console.WriteLine("Cafe selected successfully: " + currentCafe.ToString());
                        }
                        catch
                        {
                            Console.WriteLine("Cafe does not exist");
                        }
                        break;

                    case "Nearby Cafes":
                        Console.WriteLine("Please input an address");
                        string addTemp = Console.ReadLine();
                        Console.WriteLine("Please input radius (meter)");
                        double radiusTemp = Convert.ToDouble(Console.ReadLine());
                        currentCafes = Maps.NearbyCafes(Address.GetAddress(addTemp), radiusTemp);
                        int j = 1;
                        foreach (Cafe item in currentCafes)
                        {
                            Console.WriteLine(j + ". " + item.ToString());
                            j++;
                        }
                        break;

                    case "Select Cafe":
                        try
                        {
                            Console.WriteLine("Please input the name of the cafe you would like to select:");
                            string nameSelect = Console.ReadLine();
                            Console.WriteLine("Please input the address of the cafe you would like to select:");
                            string addressSelect = Console.ReadLine();
                            currentCafe = Maps.ReturnCafe(nameSelect, addressSelect);
                            Console.WriteLine("Cafe selected successfully: " + currentCafe.ToString());
                        }
                        catch
                        {
                            Console.WriteLine("Cafe does not exist");
                        }
                        break;

                    case "Register":
                        try
                        {
                            Console.WriteLine("Please input a desired username:");
                            string username = Console.ReadLine().Trim();
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
                            if (currentUser.Equals("") && sessionID.Equals(""))
                            {
                                Console.WriteLine("Please input your username:");
                                string usernameLog = Console.ReadLine().Trim();
                                Console.WriteLine("Please input your password:");
                                string passwordLog = PasswordInput();
                                sessionID = User.Auth(usernameLog, passwordLog);
                                Console.WriteLine(currentUser);
                                if (!sessionID.Equals(null))
                                {
                                    currentUser = usernameLog;
                                    Console.WriteLine("Logged in successfully");
                                }
                            }
                            else if (!currentUser.Equals("") && !sessionID.Equals(""))
                            {
                                Console.WriteLine("A User is already logged in");
                            }
                        }
                        catch
                        {
                            currentUser = "";
                            sessionID = "";
                            Console.WriteLine("Wrong Login!");
                        }
                        break;

                    case "Logout":
                        if (currentUser != "" && sessionID != "")
                        {
                            Console.WriteLine(currentUser + " Logged out");
                            sessionID = "";
                            currentUser = "";
                        }
                        else
                        {
                            Console.WriteLine("No user is logged in");
                        }
                        break;

                    case "Change Password":
                        if (currentUser != "" && sessionID != "")
                        {
                            try
                            {
                                Console.WriteLine("Please enter your new password");
                                string newPass = PasswordInput();
                                User.ChangePass(currentUser, sessionID, newPass);
                                Console.WriteLine("Password updated successfully!");
                            }
                            catch
                            {
                                Console.WriteLine("Unexpected Error");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Please login first");
                        }
                        break;

                    case "Leave Review":
                        try
                        {
                            if (sessionID != "")
                            {
                                Console.WriteLine("How much would you like to rate?");
                                decimal ratingReview = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Leave a review:");
                                string review = Console.ReadLine();
                                Review rev = new Review(review, ratingReview, currentUser, currentCafe, sessionID);
                                Console.WriteLine("Thanks for your feedback!");
                            }
                            else
                            {
                                Console.WriteLine("Please login before leaving a review");
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "Show Rating":
                        Console.WriteLine(currentCafe.Rating);
                        break;

                    case "Show Reviews":
                        if (currentCafe != null)
                        {
                            if (currentCafe.Reviews.Count != 0)
                            {
                                foreach (Review item in currentCafe.Reviews.Values)
                                {                                    
                                    Console.WriteLine(item.ToString());                                    
                                }
                            }
                            else
                            {
                                Console.WriteLine("There are no reviews yet");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please select a cafe first");
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

                    case "Open Website":
                        currentCafe.OpenWebsite();
                        break;

                    case "show current cafe":
                        try
                        {
                            Console.WriteLine(currentCafe.ToString());
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("No cafe is currently selected!");
                        }
                        break;

                    default:
                        Console.WriteLine(ErrorMessage());
                        break;
                }
            }
        }

        public static void CreateCafe()
        {
            Console.WriteLine("Please input a desired name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please input a desired street name:");
            string street = Console.ReadLine();
            Console.WriteLine("Please input the coordinates (Lat, Long accordingly):");
            double lat = Convert.ToDouble(Console.ReadLine());
            double longitude = Convert.ToDouble(Console.ReadLine());
            GeoCoordinate geo = new GeoCoordinate(lat, longitude);
            Address adr = new Address(street, geo);
            Console.WriteLine("Please input the website:");
            string website = Console.ReadLine();
            Console.WriteLine("Please input the phone number:");
            string number = Console.ReadLine();
            Console.WriteLine("Please input the opening time and closing time accordingly:");
            DateTime opening = DateTime.Parse(Console.ReadLine());
            DateTime closing = DateTime.Parse(Console.ReadLine());
            Cafe cafe = new Cafe(name, adr, website, number, opening, closing);
            Console.WriteLine("Cafe created successfully!");
        }   

        public static List<Cafe> SearchCafes()
        {
            List<Cafe> currentCafes = new List<Cafe>();
            Console.WriteLine("Please input the name of the cafe you would like to find:");
            string nameCafe = Console.ReadLine();
            Console.WriteLine("Please input the address of the cafe:");
            string address = Console.ReadLine();
            Console.WriteLine("Please input the radius:");
            double radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Search by minimum rating?");
            Console.WriteLine("Y/N");
            decimal rating = 0;
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.KeyChar != 'y' || key.KeyChar != 'n')
            {
                Console.Write("\b \b");
                if (key.KeyChar.Equals('y'))
                {
                    rating = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                else if (key.KeyChar.Equals('n'))
                {
                    break;
                }
                key = Console.ReadKey();
            }
            Console.WriteLine("Search by DateTime?");
            Console.WriteLine("Y/N");
            key = Console.ReadKey();

            while (key.KeyChar != 'y' || key.KeyChar != 'n')
            {
                Console.Write("\b \b");

                Console.Write("\b \b");
                if (key.KeyChar.Equals('y'))
                {
                    Console.Write("\b \b");
                    Console.WriteLine("Please input the opening time:");
                    DateTime openingTemp = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please input the closing time:");
                    DateTime closingTemp = DateTime.Parse(Console.ReadLine());
                    currentCafes = Maps.Search(nameCafe, address, radius, rating, openingTemp, closingTemp);
                    break;
                }
                else if (key.KeyChar.Equals('n'))
                {
                    Console.Write("\b \b");
                    currentCafes = Maps.Search(nameCafe, address, radius, rating);
                    break;
                }
                key = Console.ReadKey();
            }
            
            return currentCafes;
        }

        public static void DumpDatabase()
        {            
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            
            try
            {
                MySqlCommand selectAllCafe = new MySqlCommand("SELECT COUNT(*) FROM `cafedb`", conn);
                MySqlCommand selectAllUser = new MySqlCommand("SELECT COUNT(*) FROM `usersdb`", conn);
                MySqlCommand selectAllReview = new MySqlCommand("SELECT COUNT(*) FROM `reviewsdb`", conn);
                MySqlCommand deleteDataCafe = new MySqlCommand("DELETE FROM `cafedb` WHERE 1", conn);
                MySqlCommand deleteDataUser = new MySqlCommand("DELETE FROM `usersdb` WHERE 1", conn);
                MySqlCommand deleteDataReview = new MySqlCommand("DELETE FROM `reviewsdb` WHERE 1", conn);
                MySqlCommand addAdmin = new MySqlCommand("INSERT INTO `usersdb`(`User`,`Password`) VALUES ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')", conn);

                conn.Open();

                if (Convert.ToInt32(selectAllCafe.ExecuteScalar()) > 0 || Convert.ToInt32(selectAllUser.ExecuteScalar()) > 0 || Convert.ToInt32(selectAllReview.ExecuteScalar()) > 0)
                {
                    Prompt();
                    Console.WriteLine("Y/N");
                    ConsoleKeyInfo key = Console.ReadKey();

                    while (key.KeyChar != 'y' || key.KeyChar != 'n')
                    {
                        

                        Console.Write("\b \b");
                        if (key.KeyChar.Equals('y'))
                        {
                            Console.Write("\b \b");
                            User.Fill();
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

        public static string Help()
        {
            return "?- Displays all available commands." + '\n'
                + "Info- Displays program info." + '\n'
                + "Clear- Clears the console." + '\n'
                + "Create a Cafe- Creates a Cafe." + '\n'
                + "Search Cafes- Find specified cafe." + '\n'
                + "Nearby Cafes- Shows nearby cafes from the specified address in the specified radius" + '\n'
                + "Select Cafe- Selects a Cafe(use only if you know the location of cafe)." + '\n'
                + "Choose- Selects a cafe from the search result." + '\n'
                + "Show Reviews- Shows the reviews of a selected cafe." + '\n'
                + "Show Rating- Shows the rating of a selected cafe." + '\n'
                + "Leave Review- Leaves a review(log in first)." + '\n'
                + "Open Website- Opens the website of the selected cafe." + '\n'
                + "Register- Creates a user." + '\n'
                + "Login- Logs in a user." + '\n'
                + "Logout- Logs out a user." + '\n'
                + "Change Password- Changes password of the user." + '\n'
                + "check session- checks session(for testing)." + '\n'
                + "write session id- Writes the session id of the current user(for testing)." + '\n'
                + "show current cafe- Shows cafe currently selected." + '\n'
                + "Exit- Exits the program." + '\n';
        }

        public static string Info()
        {
            return ("Map, Project by Armen Manukyan, Areg Vrtanesyan, Samvel Baghdasaryan & Vahe Hayrapetyan, 2017");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;



namespace maps
{
    class User
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        public static void Register(string username, string password)
        {
            string hash = HashSHA256(password);
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                conn.Open();
                MySqlCommand select = new MySqlCommand(string.Format("SELECT `User` FROM `usersdb` WHERE User = '{0}' ", username), conn);
                if (select.ExecuteScalar() != null)
                {
                    throw new Exception("Username already exists");
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

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format("INSERT INTO usersdb (User, Password) VALUES ('{0}', '{1}')", username, hash), conn);
                cmd.ExecuteNonQuery();
                users.Add(username, "");
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

        private static string GenerateSessionKey()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            string input = "-_&abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder key = new StringBuilder();
            char keyChar;
            for (int i = 0; i < 32; i++)
            {
                keyChar = input[random.Next(0, input.Length)];
                key.Append(keyChar);
            }
            return key.ToString();
        }

        public static bool SessionCheck(string username, string key)
        {
            if (users[username] == key && key != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Auth(string username, string password)
        {
            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            MySqlCommand select = new MySqlCommand(string.Format("SELECT `Password` FROM `usersdb` WHERE User = '{0}'", username), conn);
            try
            {
                conn.Open();

                if (users.ContainsKey(username))
                {

                    password = HashSHA256(password);
                    if (select.ExecuteScalar().Equals(password))
                    {
                        users[username] = User.GenerateSessionKey();
                        return users[username];
                    }
                    else
                        return null;
                }
                else
                    return null;
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

        public static void ChangePass(string username, string key, string newPass)
        {
            if (SessionCheck(username, key))
            {
                string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
                newPass = HashSHA256(newPass);
                MySqlConnection conn = new MySqlConnection(conString);
                MySqlCommand select = new MySqlCommand(string.Format("UPDATE `usersdb` SET `Password`='{0}' WHERE User = '{1}'", newPass, username), conn);
                try
                {
                    conn.Open();
                    select.ExecuteNonQuery();
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
        }

        public static void FillDictionary()
        {

            string conString = "server=127.0.0.1;database=mapsdb;uid=Armen";
            MySqlConnection conn = new MySqlConnection(conString);
            try
            {
                

                MySqlCommand selectAll = new MySqlCommand("SELECT `User` FROM `usersdb` WHERE 1", conn);

                conn.Open();


                using (MySqlDataReader dr = selectAll.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        users.Add(dr.GetString("User"),"");
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
    

    private static string HashSHA256(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }
}
}

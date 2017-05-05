using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maps
{
    class User
    {
        private string username;
        private string password;
        private bool isAdmin = false;
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        private string GenerateSessionKey()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            string input = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder key = new StringBuilder();
            char keyChar;
            for (int i = 0; i < 16; i++)
            {
                keyChar = input[random.Next(0, input.Length)];
                key.Append(keyChar);
            }
            return key.ToString();
        }

        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

    }
}

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

        private string SessionKeyGenerator()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            string input = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 16; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

    }
}

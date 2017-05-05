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

        public bool IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maps
{
    class Hospital : Building
    {
        private string name;
        private string address;
        private string website;
        private string number;
        private static int count;
        public Hospital(string name, string address, string website, string number)
            : base(name, address, website, number)
        {
            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;
            count++;
        }

        public override string ToString()
        {
            return "This is a Hospital";
        }

        public string WorkingHours()
        {
            return "Hospital works 24/7";
        }
    }
}

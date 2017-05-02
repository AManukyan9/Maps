using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device;

namespace maps
{
    class Hospital : Building
    {
        private string name;
        private Address address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        private static int count;
        public Hospital(string name, Address address, string website, string number, DateTime opening, DateTime closing)
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

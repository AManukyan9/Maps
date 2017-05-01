using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maps
{
    class Hospital : Building
    {
        private string address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        private static int count;
        public Hospital(string address, string website, string number)
            : base(address, website, number)
        {
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

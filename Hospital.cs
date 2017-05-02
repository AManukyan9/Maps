using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace maps
{
    class Hospital : Building
    {
        private Address address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        private static int count;
        public Hospital(Address address, string website, string number, DateTime opening, DateTime closing)
            : base(address, website, number, opening, closing)
        {
            this.address = address;
            this.website = website;
            this.number = number;
            this.opening = opening;
            this.closing = closing;         
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

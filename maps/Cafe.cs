using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device;


namespace maps
{
    class Cafe : Building
    {
        private string address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        private static int count;
        public Cafe(string address, string website, string number, DateTime opening, DateTime closing)
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
            return "This is a cafe";
        }

        public string WorkingHours()
        {
            return this.opening.Hour + ":" + this.opening.Minute + " - " + this.closing.Hour + ":" + this.closing.Minute;
        }

        
    }
}

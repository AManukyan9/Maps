using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    class Cafe : Building
    {
        private string name;
        private Address address;
        private string website;
        private string number;
        private DateTime opening;
        private DateTime closing;
        private static int count;
        public Cafe(string name, Address address, string website, string number, DateTime opening, DateTime closing)
            : base(name, address, website, number, opening, closing)
        {
            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;
            this.opening = opening;
            this.closing = closing;
            count++;
            
        }

        public override string ToString()
        {
            if (this.name == "")
            {
                return "Cafe";
            }
            else
            {
                return "Cafe " + this.name;
            }
        }

        public string WorkingHours()
        {
            return this.opening.Hour + ":" + this.opening.Minute + " - " + this.closing.Hour + ":" + this.closing.Minute;
        }


    }
}

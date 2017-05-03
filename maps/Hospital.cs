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
        public Hospital(string name, Address address, string website, string number)
            : base(name, address, website, number)
        {
            this.name = name;
            this.address = address;
            this.website = website;
            this.number = number;      
            count++;
            Maps.AddHospital(this);
        }

        public override string ToString()
    	{
    		if(this.name == ""){
    			return "Hospital";
    		} else {
    			return "Hospital " + this.name;
    		}
    	}


        public string WorkingHours()
        {
            return "Hospital works 24/7";
        }
    }
}

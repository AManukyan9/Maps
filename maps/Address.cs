using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Drawing;

namespace maps
{
    class Address
    {
        private string addressName;
        private GeoCoordinate coord;
        private static Dictionary<string, Address> streets = new Dictionary<string, Address>();

        public Address(string addressName, GeoCoordinate coord)
        {
            this.addressName = addressName;
            this.coord = coord;

            streets.Add(this.AddressName, this);
        }
        public static Address GetAddress(string address)
        {
            if (streets.ContainsKey(address))
            {
                return streets[address];
            }
            else
            {
                throw new ArgumentException("Address not found");
            }
            
        }
        public string AddressName { get { return this.addressName; } }
        public GeoCoordinate Coord { get { return this.coord; } }
    }
}

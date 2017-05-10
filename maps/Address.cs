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

        public Address(string addressName, GeoCoordinate coord)
        {
            this.addressName = addressName;
            this.coord = coord;
        }

        public string AddressName { get { return this.addressName; } }
        public GeoCoordinate Coord { get { return this.coord; } }
    }
}

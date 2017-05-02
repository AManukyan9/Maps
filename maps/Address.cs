using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device;
using System.Drawing;

namespace maps
{
    class Address
    {
        private string addressName;
        private Point cord;

        public Address(string addressName, Point cord)
        {
            this.addressName = addressName;
            this.cord = cord;
        }

        public string AddressName { get { return this.addressName; } }
        public Point Cord { get { return this.cord; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    class Program
    {
        static void Main(string[] args)
        {
            Maps map = new Maps();
            Point addressCoord = new Point(13, 10);
            Address ad = new Address("address", addressCoord);
            Point addressCoord1 = new Point(73, 13);
            Address ad1 = new Address("address", addressCoord1);
            Point addressCoord2 = new Point(34, 2);
            Address ad2 = new Address("address", addressCoord2);
            Cafe cafe = new Cafe("Restoranchik", ad, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Cafe cafe1 = new Cafe("Restoranchik1", ad1, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Cafe cafe2 = new Cafe("Restoranchik2", ad2, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Console.WriteLine(map.FindCafe("Restoranchik2"));
                      
        }
    }
}

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
            Cafe cafe = new Cafe("Restoranchik", ad, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Cafe cafe1 = new Cafe("Restoranchik1", ad, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Cafe cafe2 = new Cafe("Restoranchik2", ad, "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            Console.WriteLine(map.FindCafe("Restoranchik"));
                      
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace maps
{
    class Program
    {
        static void Main(string[] args)
        {
            Cafe cafe = new Cafe("a", "b", "c", DateTime.Parse("10:30:00"), DateTime.Parse("19:30:00"));
            cafe.AddRating(5);
            cafe.AddRating(4);
            cafe.AddRating(5);
            cafe.AddRating(3);
            cafe.AddVisitors();
            cafe.AddVisitors();
            cafe.AddRating(5);
            cafe.AddVisitors();
            Console.WriteLine("Rating of this cafe: " + cafe.Rating);
            Console.WriteLine("Popularity rating: " + cafe.Popularity);
            Console.WriteLine(cafe.ToString());
            Console.WriteLine("Working Hours: " + cafe.WorkingHours());

            
        }
    }
}

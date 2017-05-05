using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    class Maps 
    {
        static ArrayList buildings = new ArrayList();
        static List<Cafe> cafes = new List<Cafe>();

        public static double BuildingsDistance(Address a, Address b)
        {
            return Math.Sqrt((a.Cord.X - b.Cord.X) * (a.Cord.X - b.Cord.X) + (a.Cord.Y - b.Cord.Y) * (a.Cord.Y - b.Cord.Y));
        }

        public static ArrayList Nearby(Address address, decimal radius)
        {
            throw new NotImplementedException();
        }

        public static ArrayList Search(string name = "", decimal radius = 0, decimal rating = 0)
        {
            throw new NotImplementedException();
        }

        public static ArrayList Search(Address address, string name = "", decimal radius = 0, decimal rating = 0)
        {
            throw new NotImplementedException();
        }

        public static void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        }

        public static void AddBuilding(Object bld)
        {
            buildings.Add(bld);
        }
    }

}




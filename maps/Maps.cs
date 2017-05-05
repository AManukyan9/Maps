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

        public static decimal BuildingsRadius(Address a, Address b)
        {
            throw new NotImplementedException();
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




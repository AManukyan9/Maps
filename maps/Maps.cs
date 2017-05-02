using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    interface IMaps
    {

    }

    class Maps
    {
        private static List<Building> buildings;
        private static List<Cafe> cafes;
        private static List<Hospital> hospitals;

        public static void AddCafe(Cafe cafe)
        {
            cafes.Add(cafe);
        }
        public static void AddBuilding(Building building)
        {
            buildings.Add(building);
        }
        public static void AddHospital(Hospital hospital)
        {
            hospitals.Add(hospital);
        }
    }


}

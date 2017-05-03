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
        private static Dictionary<string, Building> BuildingMap;
        private static Dictionary<string, Cafe> CafeMap;
        private static Dictionary<string, Hospital> HospitalMap;

        public static void AddCafe(Cafe cafe)
        {
            CafeMap.Add(cafe.Name, cafe);
        }
        public static void AddBuilding(Building building)
        {
            BuildingMap.Add(building.Name, building);  
        }
        public static void AddHospital(Hospital hospital)
        {
            HospitalMap.Add(hospital.Name, hospital);
        }

        public Building FindBuilding(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return BuildingMap[name];
            }
            else
            {
                throw new Exception("Building does not exist");
            }
        }
        public Cafe FindCafe(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return CafeMap[name];
            }
            else
            {
                throw new Exception("Building does not exist");
            }
        }
        public Hospital FindHospital(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return HospitalMap[name];
            }
            else
            {
                throw new Exception("Building does not exist");
            }
        }

    }


}

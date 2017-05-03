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
        private static Dictionary<string, Building> BuildingMap = new Dictionary<string, Building>();
        private static Dictionary<string, Cafe> CafeMap = new Dictionary<string, Cafe>();
        private static Dictionary<string, Hospital> HospitalMap = new Dictionary<string, Hospital>();

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

        public string FindBuilding(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return BuildingMap[name].ToString() + " located at " + BuildingMap[name].Address.Cord;
            }
            else
            {
                throw new Exception("Building does not exist");
            }
        }
        public string FindCafe(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return CafeMap[name].ToString() + " located at " + CafeMap[name].Address.Cord;
            }
            else
            {
                throw new Exception(" does not exist");
            }
        }
        public string FindHospital(string name)
        {
            if (BuildingMap.ContainsKey(name))
            {
                return HospitalMap[name].ToString() + " located at " + HospitalMap[name].Address.Cord;
            }
            else
            {
                throw new Exception("Hospital does not exist");
            }
        }

    }


}

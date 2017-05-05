using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace maps
{
    static class Maps 
    {
        static ArrayList buildings = new ArrayList();

        public static double BuildingsDistance(Address a, Address b)
        {
            return Math.Sqrt((a.Cord.X - b.Cord.X) * (a.Cord.X - b.Cord.X) + (a.Cord.Y - b.Cord.Y) * (a.Cord.Y - b.Cord.Y));
        }

        public static ArrayList Nearby(Address address, double radius)
        {
            ArrayList returnBuildings = new ArrayList();
            for (int i = 0; i < buildings.Count; i++)
            {    
                if (BuildingsDistance(address, ((Building)buildings[i]).Address) <= radius)
                {
                    returnBuildings.Add(buildings[i]);
                }
            }
            return returnBuildings;
        }

        public static ArrayList Search(Address address = null, string name = "", decimal rating = 0)
        {
            ArrayList returnBuildings = new ArrayList();
            bool[] filled = new bool[buildings.Count];
            if (address == null)
            {
                if (name != "")
                {
                    for (int i = 0; i < buildings.Count; i++)
                    {
                        if ((((Building)buildings[i]).Name == name && ((Building)buildings[i]).Rating >= rating) && filled[i] != true)
                        {
                            returnBuildings.Add(buildings[i]);
                            filled[i] = true;
                        }
                    }
                }
                for (int i = 0; i < buildings.Count; i++)
                {
                    if ((((Building)buildings[i]).Name == name || ((Building)buildings[i]).Rating >= rating) && filled[i] != true)
                    {
                        returnBuildings.Add(buildings[i]);
                        filled[i] = true;
                    }
                }
            }
            else
            {
                if (name != "")
                {
                    for (int i = 0; i < buildings.Count; i++)
                    {
                        if ((((Building)buildings[i]).Address == address && ((Building)buildings[i]).Name == name && ((Building)buildings[i]).Rating >= rating) && filled[i] != true)
                        {
                            returnBuildings.Add(buildings[i]);
                            filled[i] = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < buildings.Count; i++)
                    {
                        if ((((Building)buildings[i]).Address == address && ((Building)buildings[i]).Rating >= rating) && filled[i] != true)
                        {
                            returnBuildings.Add(buildings[i]);
                            filled[i] = true;
                        }
                    }
                }
                for (int i = 0; i < buildings.Count; i++)
                {
                    if ((((Building)buildings[i]).Address == address || ((Building)buildings[i]).Name == name ||((Building)buildings[i]).Rating >= rating) && filled[i] != true)
                    {
                        returnBuildings.Add(buildings[i]);
                        filled[i] = true;
                    }
                }

            }     
            return returnBuildings;   
        }

    }

}




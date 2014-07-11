using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Map
    {
        [Obsolete("Warning: Uses fixed seed")]
        public List<City> GetCities(int count, int maxX, int maxY)
        {
            Random rand = new Random(1);
            List<City> cities = new List<City>();
            for (int i = 0; i < count; i++)
            {
                cities.Add(new City(rand.Next(maxX), rand.Next(maxY), i.ToString()));
            }
            return cities;
        }
    }
}

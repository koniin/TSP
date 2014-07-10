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
        public IEnumerable<City> GetCities(int count, int maxX, int maxY)
        {
            Random rand = new Random(1);

            for (int i = 0; i < count; i++)
            {
                yield return new City(rand.Next(maxX), rand.Next(maxY), i.ToString());
            }
        }
    }
}

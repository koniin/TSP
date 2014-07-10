using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class City
    {
        public City(double x, double y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public double Distance(City c)
        {
            return Math2D.Distance(X, Y, c.X, c.Y);
        }

        public double X { get; private set; }
        public double Y { get; private set; }
        public string Name { get; set; }
    }
}

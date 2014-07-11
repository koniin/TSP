using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Chromosome
    {
        public List<City> Cities { get; private set; }

        public Chromosome(List<City> cities) 
        {
            Cities = cities;
        }

        public double Fitness()
        {
            double fitness = 0;
            for(int i = 0; i < Cities.Count - 1; i++)
                fitness += Math2D.Distance(Cities[i].X, Cities[i].Y, Cities[i + 1].X, Cities[i + 1].Y);
            return fitness;
        }
    }
}

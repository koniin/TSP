using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Population
    {
        public List<Chromosome> Chromosomes { get; private set; }

        public Population()
        {
            Chromosomes = new List<Chromosome>();
        }

        public void Add(Chromosome child)
        {
            Chromosomes.Add(child);
        }

        public Chromosome GetBestChromosome()
        {
            double bestFitness = double.MaxValue;
            Chromosome bestChromosome = null;
            foreach (Chromosome c in Chromosomes)
            {
                if (c.Fitness() < bestFitness)
                {
                    bestChromosome = c;
                    bestFitness = c.Fitness();
                }
            }
            return bestChromosome;
        }

        public static Population CreateRandomPopulation(List<City> availableCities, int populationSize)
        {
            Population p = new Population();
            for (int i = 0; i < populationSize; i++)
                p.Add(Chromosome.CreateRandomChromosome(availableCities));
            return p;
        }
    }
}

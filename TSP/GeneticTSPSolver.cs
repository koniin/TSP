using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class GeneticTSPSolver : ITSPSolver
    {
        /*
         *      1.     [Start] Generate random population of n chromosomes (suitable solutions for the problem)
                2.     [Fitness] Evaluate the fitness f(x) of each chromosome x in the population
                3.     [New population] Create a new population by repeating following steps until the new population is complete
                    1.     [Selection] Select two parent chromosomes from a population according to their fitness (the better fitness, the bigger chance to be selected) http://www.obitko.com/tutorials/genetic-algorithms/selection.php
                    2.     [Crossover] With a crossover probability cross over the parents to form a new offspring (children). If no crossover was performed, offspring is an exact copy of parents.
                    3.     [Mutation] With a mutation probability mutate new offspring at each locus (position in chromosome).
                    4.     [Accepting] Place new offspring in a new population
                4.     [Replace] Use new generated population for a further run of algorithm
                5.     [Test] If the end condition is satisfied, stop, and return the best solution in current population
                6.     [Loop] Go to step 2

         * */

        /*
         * 
         * Crossover rate
            Crossover rate generally should be high, about 80%-95%. (However some results show that for some problems crossover rate about 60% is the best.)
            
         * Mutation rate
            On the other side, mutation rate should be very low. Best rates reported are about 0.5%-1%.
            
         * Population size
            It may be surprising, that very big population size usually does not improve performance of GA (in meaning of speed of finding solution). 
         * Good population size is about 20-30, however sometimes sizes 50-100 are reported as best. Some research also shows, 
         * that best population size depends on encoding, on size of encoded string. It means, if you have chromosome with 32 bits, the population should be say 32, 
         * but surely two times more than the best population size for chromosome with 16 bits.
         * */

        // Chromosome is the order that the cities are visited in

        // Crossover; one crossover point is selected, till this point the permutation is copied from the first parent, 
        //            then the second parent is scanned and if the number is not yet in the offspring it is added

        // Mutation is when two (or more) cities change place at random
        
        public List<City> Solve(List<City> availableCities)
        {
            int populationSize = availableCities.Count;

            Population pop = CreateRandomPopulation(availableCities, populationSize);

            Population nextGeneration = new Population();
            for (int i = 0; i < populationSize; i++)
            {
                ChromosomePair parents = GetHighestRankedChromosomes(pop.Chromosomes);

                Chromosome child;
                if (ShouldPerformCrossover())
                    child = PerformCrossover(parents);
                else
                    child = CopyParents(parents);

                if (ShouldMutate())
                    child = MutateChild(child);

                nextGeneration.Add(child);
            }

            return nextGeneration.GetBestChromosome().Cities;
        }

        public ChromosomePair GetHighestRankedChromosomes(List<Chromosome> chromosomes)
        {
            return new ChromosomePair(chromosomes[0], chromosomes[1]);
        }

        public Population CreateRandomPopulation(List<City> availableCities, int populationSize)
        {
            Population p = new Population();
            for (int i = 0; i < populationSize; i++)
                p.Add(CreateRandomChromosome(availableCities));
            return p;
        }

        public Chromosome CreateRandomChromosome(List<City> availableCities)
        {
            return new Chromosome(availableCities);
        }

        private bool ShouldPerformCrossover()
        {
            return true;
        }

        private bool ShouldMutate()
        {
            return true;
        }

        private Chromosome PerformCrossover(ChromosomePair parents)
        {
            return new Chromosome(parents.Father.Cities);
        }

        private Chromosome CopyParents(ChromosomePair parents)
        {
            return new Chromosome(parents.Father.Cities);
        }

        private Chromosome MutateChild(Chromosome child)
        {
            return child;
        }
    }
}

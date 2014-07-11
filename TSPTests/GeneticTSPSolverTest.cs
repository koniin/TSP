using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSP;
using System.Collections.Generic;

namespace TSPTests
{
    [TestClass]
    public class GeneticTSPSolverTest
    {
        private GeneticTSPSolver geneticTSPSolver = new GeneticTSPSolver();

        [TestMethod]
        public void GeneticTSPSolver_Solve_NotNullInCollection()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));
            cities.Add(new City(5, 5, "B"));
            cities.Add(new City(10, 10, "C"));
            cities.Add(new City(20, 20, "D"));
            cities.Add(new City(30, 30, "E"));

            List<City> solution = geneticTSPSolver.Solve(cities);
            CollectionAssert.AllItemsAreNotNull(solution);
        }

        [TestMethod]
        public void GeneticTSPSolver_Solve_CollectionNotEmpty()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));
            cities.Add(new City(5, 5, "B"));
            cities.Add(new City(10, 10, "C"));
            cities.Add(new City(20, 20, "D"));
            cities.Add(new City(30, 30, "E"));

            List<City> solution = geneticTSPSolver.Solve(cities);

            Assert.AreNotEqual<int>(0, solution.Count);
        }

        [TestMethod]
        public void GeneticTSPSolver_GetHighestRankedChromosomes()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));
            cities.Add(new City(2, 2, "B"));
            cities.Add(new City(3, 3, "C"));
            cities.Add(new City(4, 4, "D"));
            cities.Add(new City(5, 5, "E"));

            List<City> cities2 = new List<City>();
            cities2.Add(new City(1, 1, "A"));
            cities2.Add(new City(5, 5, "B"));
            cities2.Add(new City(300, 300, "C"));
            cities2.Add(new City(4, 4, "D"));
            cities2.Add(new City(200, 200, "E"));

            List<City> cities3 = new List<City>();
            cities3.Add(new City(1, 1, "A"));
            cities3.Add(new City(5, 5, "B"));
            cities3.Add(new City(3, 3, "C"));
            cities3.Add(new City(4, 4, "D"));
            cities3.Add(new City(2, 2, "E"));

            Chromosome c = new Chromosome(cities);
            Chromosome c2 = new Chromosome(cities2);
            Chromosome c3 = new Chromosome(cities3);

            List<Chromosome> chromosomes = new List<Chromosome>();
            chromosomes.Add(c);
            chromosomes.Add(c2);
            chromosomes.Add(c3);

            ChromosomePair pair = geneticTSPSolver.GetHighestRankedChromosomes(chromosomes);

            Assert.AreEqual(c, pair.Father);
            Assert.AreEqual(c3, pair.Mother);
        }
    }
}

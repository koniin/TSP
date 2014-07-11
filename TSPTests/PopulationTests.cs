using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSP;
using System.Collections.Generic;

namespace TSPTests
{
    [TestClass]
    public class PopulationTests
    {
        [TestMethod]
        public void Population_Create()
        {
            Population p = new Population();

            Assert.IsNotNull(p.Chromosomes);
            Assert.AreEqual<int>(0, p.Chromosomes.Count);
        }

        [TestMethod]
        public void Population_AddChromoSome()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));

            Population p = new Population();
            Chromosome c = new Chromosome(cities);
            p.Add(c);

            Assert.AreEqual(c, p.Chromosomes[0]);
        }

        [TestMethod]
        public void Population_GetBestChromosome()
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
            cities2.Add(new City(3, 3, "C"));
            cities2.Add(new City(4, 4, "D"));
            cities2.Add(new City(2, 2, "E"));

            Population p = new Population();
            Chromosome c = new Chromosome(cities);
            Chromosome c2 = new Chromosome(cities2);

            p.Add(c);
            p.Add(c2);

            Chromosome best = p.GetBestChromosome();

            Assert.AreEqual(c, best);
        }

        [TestMethod]
        public void Population_CreateRandomPopulation()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));
            cities.Add(new City(2, 2, "B"));
            cities.Add(new City(3, 3, "C"));
            cities.Add(new City(4, 4, "D"));
            cities.Add(new City(5, 5, "E"));

            Population pop = Population.CreateRandomPopulation(cities, cities.Count);

            Assert.AreEqual<int>(pop.Chromosomes.Count, cities.Count);
        }
    }
}

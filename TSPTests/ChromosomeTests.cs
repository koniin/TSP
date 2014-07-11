using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSP;
using System.Collections.Generic;

namespace TSPTests
{
    [TestClass]
    public class ChromosomeTests
    {
        [TestMethod]
        public void Chromosome_Calculate_Fitness()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 2, "A"));
            cities.Add(new City(5, 5, "B"));

            Chromosome c = new Chromosome(cities);
            Assert.AreEqual<double>(5, c.Fitness());
        }

        [TestMethod]
        public void Chromosome_Calculate_Fitness_5Nodes()
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, 1, "A"));
            cities.Add(new City(5, 5, "B"));
            cities.Add(new City(10, 10, "C"));
            cities.Add(new City(20, 20, "D"));
            cities.Add(new City(30, 30, "E"));

            Chromosome c = new Chromosome(cities);
            Assert.AreEqual<double>(41.01219331, Math.Round(c.Fitness(), 8));
        }
    }
}

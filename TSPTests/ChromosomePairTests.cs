using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSP;
using System.Collections.Generic;

namespace TSPTests
{
    [TestClass]
    public class ChromosomePairTests
    {
        [TestMethod]
        public void ChromosomePair_CreateCrossoverChild()
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

            Chromosome c = new Chromosome(cities);
            Chromosome c2 = new Chromosome(cities2);

            ChromosomePair pair = new ChromosomePair(c, c2);

            Chromosome child = pair.CreateCrossoverChild();

            Assert.AreNotEqual(c, child);
        }

        [TestMethod]
        public void ChromosomePair_CreateChild()
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

            Chromosome c = new Chromosome(cities);
            Chromosome c2 = new Chromosome(cities2);

            ChromosomePair pair = new ChromosomePair(c, c2);

            Chromosome child = pair.CreateChild();

            Assert.AreNotEqual(c, child);
        }
    }
}

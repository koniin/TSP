using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSP;
using System.Collections.Generic;

namespace TSPTests
{
    [TestClass]
    public class MapTests
    {
        private Map map = new Map();

        [TestMethod]
        public void Map_Returns_OK()
        {
            List<City> cities = map.GetCities(3, 1, 1);
            Assert.AreEqual<int>(3, cities.Count);
        }
    }
}

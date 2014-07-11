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
            List<City> solution = geneticTSPSolver.Solve(cities);
            CollectionAssert.AllItemsAreNotNull(solution);
        }

        [TestMethod]
        public void GeneticTSPSolver_Solve_CollectionNotEmpty()
        {
            List<City> cities = new List<City>();
            List<City> solution = geneticTSPSolver.Solve(cities);

            Assert.AreNotEqual<int>(0, solution.Count);
        }
    }
}

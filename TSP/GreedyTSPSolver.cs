using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class GreedyTSPSolver : ITSPSolver
    {
        private List<City> visitationOrder = new List<City>();

        public List<City> Solve(List<City> availableCities)
        {
            City firstCity = availableCities.First();
            GetCheapestCityFrom(availableCities.First(), availableCities.Where(cc => cc.Name != firstCity.Name));
            return visitationOrder;
        }

        private void GetCheapestCityFrom(City startNode, IEnumerable<City> availableCities)
        {
            if (!availableCities.Any())
                return;

            City next = startNode;
            double lowestCost = double.MaxValue;
            foreach (City c in availableCities)
            {
                double cost = startNode.Distance(c);
                if (cost < lowestCost)
                {
                    next = c;
                    lowestCost = cost;
                }
            }

            visitationOrder.Add(next);
            GetCheapestCityFrom(next, availableCities.Where(cc => cc.Name != next.Name));
        }
    }
}

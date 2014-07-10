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

        public IEnumerable<City> Solve(City startNode, IEnumerable<City> availableCities)
        {
            GetCheapestCityFrom(startNode, availableCities);
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

        /*
        private void GetCheapestRelation(City currentNode)
        {
            Relation cheapestRelation = null;
            int currentCost = int.MaxValue;
            foreach (Relation r in currentNode.Relations)
            {
                if (r.Cost < currentCost && !relations.Any(re => re.Current.Name == r.Next.Name))
                {
                    currentCost = r.Cost;
                    cheapestRelation = r;
                }
            }

            if (cheapestRelation == null)
                return;

            relations.Add(cheapestRelation);
            GetCheapestRelation(cheapestRelation.Next);
        }*/
    }
}

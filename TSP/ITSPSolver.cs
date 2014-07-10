using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public interface ITSPSolver
    {
        IEnumerable<City> Solve(City startNode, IEnumerable<City> availableCities);
    }
}

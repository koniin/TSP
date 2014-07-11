using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    public interface ITSPSolver
    {
        List<City> Solve(List<City> availableCities);
    }
}

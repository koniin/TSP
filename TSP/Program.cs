using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Map m = new Map();
            SolveGraph(m.GetCities(3, 10, 10));

            Console.Read();
        }

        private static void SolveGraph(List<City> nodes)
        {
            Console.WriteLine("Shortest Path is: ");

            Console.WriteLine("Greedy");
            ITSPSolver tspSolver = new GreedyTSPSolver();
            GetSolution(nodes, tspSolver);

            Console.WriteLine("Genetic");
            tspSolver = new GeneticTSPSolver();
            GetSolution(nodes, tspSolver);
        }

        private static void GetSolution(List<City> nodes, ITSPSolver tspSolver)
        {
            foreach (City n in tspSolver.Solve(nodes))
            {
                Console.Write(n.Name);
                Console.Write(" -> ");
            }
            Console.Write(nodes[0].Name);
            Console.WriteLine("\n");
        }
    }
}

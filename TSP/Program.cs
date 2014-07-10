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
            /*
            ProblemManager m = new ProblemManager();

            SolveGraph(m.GetDirectedGraph());

            SolveGraph(m.GetUnDirectedGraph());
            */
            Console.Read();
        }

        private static void SolveGraph(IEnumerable<City> nodes)
        {
            Console.WriteLine("Shortest Path is: ");

            Console.WriteLine("FirstRelationSolver");
            ITSPSolver tspSolver = new FirstRelationTSPSolver();
            GetSolution(nodes.First(), tspSolver);

            Console.WriteLine("Greedy");
            tspSolver = new GreedyTSPSolver();
            GetSolution(nodes.First(), tspSolver);
        }

        private static void GetSolution(City startingNode, ITSPSolver tspSolver)
        {
            /*
            foreach (Relation n in tspSolver.Solve(startingNode))
            {
                Console.Write(n.Current.Name);
                Console.Write(" -> ");
                Console.Write(n.Next.Name);
                Console.Write(", ");
                Console.Write(n.Cost);
                Console.Write("\n");
            }*/
        }
    }
}

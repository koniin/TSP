using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TSP;

namespace VisualizeGraphs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GraphicsBuilder graphicsBuilder;
        private Map map;
        private Graph graph;

        public MainWindow()
        {
            InitializeComponent();

            map = new Map();
            graphicsBuilder = new GraphicsBuilder();
            graph = new Graph(graphicsBuilder);

            List<City> cities = map.GetCities(15, 700, 500);

            graph.Draw(GraphCanvas, cities);
            
            GreedyTSPSolver tspSolver = new GreedyTSPSolver();
            City start = cities.ElementAt(0);
            IEnumerable<City> solution = tspSolver.Solve(cities);

            graph.DrawSolution(GraphCanvas, new[] { start }.Concat(solution.Concat(new[] { start })));
        }
    }
}

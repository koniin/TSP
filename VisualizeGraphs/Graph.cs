using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using TSP;

namespace VisualizeGraphs
{
    public class Graph
    {
        GraphicsBuilder graphicsBuilder;

        public Graph(GraphicsBuilder graphicsBuilder)
        {            
            this.graphicsBuilder = graphicsBuilder;
        }

        public void Draw(Canvas drawTarget, IEnumerable<City> cities)
        {
            drawTarget.Children.Clear();

            foreach (City city in cities)
            {
                Path path = graphicsBuilder.BuildPointWithText(city.Name, city.X, city.Y);
                drawTarget.Children.Add(path);

                foreach (City c in cities.Where(cc => cc.Name != city.Name))
                {
                    if (IsNotDrawnConnection(city, c))
                    {
                        Path p = graphicsBuilder.BuildLineWithText(GetFormattedDistance(CalculateDistance(city, c)), city.X, city.Y, c.X, c.Y);
                        drawTarget.Children.Add(p);
                        AddToDrawnConnection(city, c);
                    }
                }
            }
        }

        public void DrawSolution(Canvas drawTarget, IEnumerable<City> cities)
        {
            drawTarget.Children.Add(graphicsBuilder.BuildText(string.Join(" -> ", cities.Select(c => c.Name)), 20, 540));
        }

        private HashSet<string> drawnConnections = new HashSet<string>();
        private void AddToDrawnConnection(City city, City c)
        {
            drawnConnections.Add(GetConnectionKey(city, c));
            drawnConnections.Add(GetConnectionKey(c, city));
        }

        private string GetConnectionKey(City city, City c)
        {
            return city.Name + "-" + c.Name;
        }

        private bool IsNotDrawnConnection(City city, City c)
        {
            return !drawnConnections.Contains(GetConnectionKey(city, c));
        }

        private string GetFormattedDistance(double distance)
        {
            return string.Format("{0:0}", distance);
        }

        private double CalculateDistance(City p1, City p2)
        {
            return Math2D.Distance(p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}

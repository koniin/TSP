using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VisualizeGraphs
{
    public class GraphicsBuilder
    {
        private readonly SolidColorBrush[] brushes;
        private readonly Random random;

        public GraphicsBuilder()
        {
            random = new Random();
            brushes = new SolidColorBrush[] {
                Brushes.Teal,
                Brushes.Black,
                Brushes.Blue,
                Brushes.DarkGray,
                Brushes.DarkRed,
                Brushes.Gray,
                Brushes.HotPink,
                Brushes.LawnGreen,
                Brushes.Red,
                Brushes.LightGray
            };
        }

        public Path BuildPointWithText(string text, double x, double y)
        {
            EllipseGeometry myEllipseGeometry1 = GetEllipseGeometry(x, y);
            Geometry textgeo1 = GetTextGeometry(text, x + myEllipseGeometry1.Bounds.Width, y);
            GeometryGroup gg = new GeometryGroup();
            gg.Children.Add(textgeo1);
            gg.Children.Add(myEllipseGeometry1);

            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.Fill = Brushes.LightGreen;
            myPath.StrokeThickness = 1;
            myPath.Data = gg;
            return myPath;
        }

        public Path BuildLineWithText(string text, double x1, double y1, double x2, double y2)
        {
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new Point(x1, y1);
            myLineGeometry.EndPoint = new Point(x2, y2);

            Geometry textgeo1 = GetTextGeometry(text, GetCenterPoint(x1, x2) + 15, GetCenterPoint(y1, y2));

            GeometryGroup gg = new GeometryGroup();
            gg.Children.Add(myLineGeometry);
            gg.Children.Add(textgeo1);

            Path p = new Path();
            p.Stroke = GetRandomBrush();
            p.StrokeThickness = 1;
            p.Data = gg;
            return p;
        }

        public Path BuildText(string text, double x, double y)
        {
            Geometry textgeo1 = GetTextGeometry(text, x, y);
            
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.Fill = Brushes.White;
            myPath.StrokeThickness = 1;
            myPath.Data = textgeo1;
            return myPath;
        }

        private Geometry GetTextGeometry(string text, double x, double y)
        {
            FormattedText text1 = new FormattedText(text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Tahoma"),
                11,
                Brushes.Black);

            Geometry textgeo1 = text1.BuildGeometry(new Point(x, y));
            return textgeo1;
        }

        private EllipseGeometry GetEllipseGeometry(double x, double y)
        {
            EllipseGeometry myEllipseGeometry = new EllipseGeometry();
            myEllipseGeometry.Center = new Point(x, y);
            myEllipseGeometry.RadiusX = 4;
            myEllipseGeometry.RadiusY = 4;
            return myEllipseGeometry;
        }

        private double GetCenterPoint(double p1, double p2)
        {
            return (p1 + p2) / 2;
        }

        private SolidColorBrush GetRandomBrush()
        {
            return brushes[random.Next(brushes.Length)];
        }
    }
}

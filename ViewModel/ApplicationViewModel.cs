using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figure = Model.Figure;
using Point = Model.Point;
using Line = Model.Line;
using Ellipse = Model.Ellipse;
using Rectangle = Model.Rectangle;

namespace ViewModel
{
    public class ApplicationViewModel
    {
        public Point ParsePointFromString(string source)
        {
            var coord = source.Split(";");

            double x = Convert.ToDouble(coord[0]);
            double y = Convert.ToDouble(coord[1]);

            return new Point(x, y);
        }

        public Rectangle ParseRectangleFromString(string source)
        {
            var coords = source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var point1 = ParsePointFromString(coords[0]);
            var point2 = ParsePointFromString(coords[1]);
            var point3 = ParsePointFromString(coords[2]);
            var point4 = ParsePointFromString(coords[3]);

            return new Rectangle(point1, point2, point3, point4);
        }


        public Ellipse ParseEllipseFromString(string source)
        {
            var coords = source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var pointFrom = ParsePointFromString(coords[0]);
            var radius = Convert.ToDouble(coords[1]);

            return new Ellipse(pointFrom, radius);
        }

        public Line ParseLineFromString(string source)
        {
            var coords = source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Console.WriteLine(source);
            Console.WriteLine(coords[0] + " " + coords[1]);
            var pointFrom = ParsePointFromString(coords[0]);
            var pointTo = ParsePointFromString(coords[1]);

            return new Line(pointFrom, pointTo);
        }
    }
}

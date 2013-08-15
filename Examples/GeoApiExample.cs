using GeoAPI.Geometries;
using GeographicLib;
using System;
using System.Collections.Generic;

namespace Examples
{
    class GeoApiExample
    {
        static void Main(string[] args)
        {
            var points = new List<Coordinate>();

            points.Add(new Coordinate(76.46271622769265, 27.2189096002747));
            points.Add(new Coordinate(76.46343557772907, 27.22019906944509));
            points.Add(new Coordinate(76.533750407584, 27.27854099851115));
            points.Add(new Coordinate(76.60373289912737, 27.33203905675748));
            points.Add(new Coordinate(76.73505077434683, 27.25082673316215));
            points.Add(new Coordinate(76.7647230800377, 27.17538729876349));
            points.Add(new Coordinate(76.7009396078775, 27.13737063609517));
            points.Add(new Coordinate(76.69514474007981, 27.13028173548244));
            points.Add(new Coordinate(76.59237872667573, 27.07612452223757));
            points.Add(new Coordinate(76.49339743712328, 27.1185586620033));
            points.Add(new Coordinate(76.48972181592471, 27.12562618352793));
            points.Add(new Coordinate(76.45637281051093, 27.18668202073895));
            points.Add(new Coordinate(76.45712044398469, 27.18796007572145));
            points.Add(new Coordinate(76.45717703146612, 27.18922485527056));
            points.Add(new Coordinate(76.45986519653313, 27.20923863745514));

            Console.WriteLine("\n*********** Calculating Length ***********\n");

            CalculateLength(points);
            Console.WriteLine("\n***** Calculating Area & Perimeter *****\n");

            CalculateArea(points);
            Console.WriteLine("\n**** Calculating Incremental Length ****\n");

            CalcuateLenghtIncrements(points);


            Console.ReadLine();

        }

        private static void CalcuateLenghtIncrements(List<Coordinate> points)
        {
            // setting the polyline to true allows us 
            // to calculate length of a polyline
            var calc = new PolygonArea(Geodesic.WGS84, true);
            foreach (var point in points)
            {
                calc.AddPoint(point.X, point.Y);
                var length = calc.Compute().Perimeter;
                Console.WriteLine("Adding Point({0},{1}) : Curent Length : {2}", point.X, point.Y,length);
            }
        }

        private static void CalculateArea(List<Coordinate> points)
        {
            // setting the polyline to false allows us 
            // to calculate length of a polyline
            var calc = new PolygonArea(Geodesic.WGS84, false);
            foreach (var point in points)
            {
                calc.AddPoint(point.X, point.Y);
            }
            var area = calc.Compute();
            Console.WriteLine("Area Is      : {0}", area.Area);
            Console.WriteLine("Perimeter Is : {0}", area.Perimeter);

        }

        private static void CalculateLength(List<Coordinate> points)
        {
            // setting the polyline to true allows us 
            // to calculate length of a polyline
            var calc = new PolygonArea(Geodesic.WGS84, true);
            foreach (var point in points)
            {
                calc.AddPoint(point.X, point.Y);
            }
            var length = calc.Compute().Perimeter;
            Console.WriteLine("Length Is : {0}", length);

        }






    }
}

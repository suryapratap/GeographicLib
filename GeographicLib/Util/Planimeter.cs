/**
 * A test program for the GeographicLib.PolygonArea class
 **********************************************************************/

using GeographicLib;
using System.Linq;
using System;
/**
 * Compute the area of a geodesic polygon.
 *
 * This program reads lines with lat, lon for each vertex of a polygon.  At the
 * end of input, the program prints the number of vertices, the perimeter of
 * the polygon and its area (for the WGS84 ellipsoid).
 **********************************************************************/
namespace GeographicLib.Util
{
    public class Planimeter
    {
        public static void main(string[] args)
        {
            PolygonArea p = new PolygonArea(Geodesic.WGS84, false);
            try
            {
                var inp = (from arg in args select double.Parse(arg)).GetEnumerator();
                while (inp.MoveNext())
                {
                    double lat = inp.Current;
                    inp.MoveNext();
                    double lon = inp.Current;
                    p.AddPoint(lat, lon);
                }
            }
            catch (Exception e) { }
            PolygonResult r = p.Compute();
            Console.WriteLine(r.Num + " " + r.Perimeter + " " + r.Area);
        }
    }
}

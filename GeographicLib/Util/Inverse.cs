/**
 * A test program for the GeographicLib.Geodesic.Inverse method
 **********************************************************************/

using System;
using System.Linq;
using GeographicLib;
/**
 * Solve the inverse geodesic problem.
 *
 * This program reads in lines with lat1, lon1, lat2, lon2 and prints out lines
 * with azi1, azi2, s12 (for the WGS84 ellipsoid).
 **********************************************************************/
namespace GeographicLib.Util
{
    public class Inverse
    {
        public static void main(String[] args)
        {
            try
            {
                var inp = (from arg in args select double.Parse(arg)).GetEnumerator();
                double lat1, lon1, lat2, lon2;
                while (inp.MoveNext())
                {
                    lat1 = inp.Current; inp.MoveNext();
                    lon1 = inp.Current; inp.MoveNext();
                    lat2 = inp.Current; inp.MoveNext();
                    lon2 = inp.Current;
                    GeodesicData g = Geodesic.WGS84.Inverse(lat1, lon1, lat2, lon2);
                    Console.WriteLine(g.azi1 + " " + g.azi2 + " " + g.s12);
                }
            }
            catch (Exception e) { }
        }
    }
}
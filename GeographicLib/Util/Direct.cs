/**
 * A test program for the GeographicLib.Geodesic.Direct method
 **********************************************************************/
using System;
using System.Linq;
using GeographicLib;

namespace GeographicLib.Util
{
    public class Direct
    {
        /**
         * Solve the direct geodesic problem.
         *
         * This program reads in lines with lat1, lon1, azi1, s12 and prints out lines
         * with lat2, lon2, azi2 (for the WGS84 ellipsoid).
         **********************************************************************/
        public static void main(String[] args)
        {
            try
            {
                var inp = (from arg in args select double.Parse(arg)).GetEnumerator();
                double lat1, lon1, azi1, s12;
                while (inp.MoveNext())
                {
                    lat1 = inp.Current; inp.MoveNext();
                    lon1 = inp.Current; inp.MoveNext();
                    azi1 = inp.Current; inp.MoveNext();
                    s12 = inp.Current;
                    GeodesicData g = Geodesic.WGS84.Direct(lat1, lon1, azi1, s12);
                    Console.WriteLine(g.lat2 + " " + g.lon2 + " " + g.azi2);
                }
            }
            catch (Exception e) { }
        }
    }
}

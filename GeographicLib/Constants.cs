/**
 * Implementation of the net.sf.geographiclib.Constants class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{

    /// <summary>
    ///   Constants needed by GeographicLib.
    ///   Define constants specifying the WGS84 ellipsoid.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The equatorial radius of WGS84 ellipsoid (6378137 m)
        /// </summary>
        public static readonly double WGS84_a = 6378137;

        /// <summary>
        /// The flattening of WGS84 ellipsoid (1/298.257223563).
        /// </summary>
        public static readonly double WGS84_f = 1 / 298.257223563;

        private Constants() { }
    }




}
/**
 * Implementation of the net.sf.geographiclib.GeodesicMask class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{

    /**
     * Bit masks for what geodesic calculations to do.
     * <p>
     * These masks do double duty.  They specify (via the <i>outmask</i> parameter)
     * which results to return in the {@link GeodesicData} object returned by the
     * general routines {@link Geodesic#Direct(double, double, double, double, int)
     * Geodesic.Direct} and {@link Geodesic#Inverse(double, double, double, double,
     * int) Geodesic.Inverse} routines.  They also signify (via the <i>caps</i>
     * parameter) to the {@link GeodesicLine#GeodesicLine(Geodesic, double, double,
     * double, int) GeodesicLine.GeodesicLine} constructor and to {@link
     * Geodesic#Line(double, double, double, int) Geodesic.Line} what capabilities
     * should be included in the {@link GeodesicLine} object.
     **********************************************************************/
    public class GeodesicMask
    {
        internal static readonly int CAP_NONE = 0;
        internal static readonly int CAP_C1 = 1 << 0;
        internal static readonly int CAP_C1p = 1 << 1;
        internal static readonly int CAP_C2 = 1 << 2;
        internal static readonly int CAP_C3 = 1 << 3;
        internal static readonly int CAP_C4 = 1 << 4;
        internal static readonly int CAP_ALL = 0x1F;
        internal static readonly int OUT_ALL = 0x7F80;

        /**
         * No capabilities, no output.
         **********************************************************************/
        public static readonly int NONE = 0;
        /**
         * Calculate latitude <i>lat2</i>.  (It's not necessary to include this as a
         * capability to {@link GeodesicLine} because this is included by default.)
         **********************************************************************/
        public static readonly int LATITUDE = 1 << 7 | CAP_NONE;
        /**
         * Calculate longitude <i>lon2</i>.
         **********************************************************************/
        public static readonly int LONGITUDE = 1 << 8 | CAP_C3;
        /**
         * Calculate azimuths <i>azi1</i> and <i>azi2</i>.  (It's not necessary to
         * include this as a capability to {@link GeodesicLine} because this is
         * included by default.)
         **********************************************************************/
        public static readonly int AZIMUTH = 1 << 9 | CAP_NONE;
        /**
         * Calculate distance <i>s12</i>.
         **********************************************************************/
        public static readonly int DISTANCE = 1 << 10 | CAP_C1;
        /**
         * Allow distance <i>s12</i> to be used as <i>input</i> in the direct
         * geodesic problem.
         **********************************************************************/
        public static readonly int DISTANCE_IN = 1 << 11 | CAP_C1 | CAP_C1p;
        /**
         * Calculate reduced length <i>m12</i>.
         **********************************************************************/
        public static readonly int REDUCEDLENGTH = 1 << 12 | CAP_C1 | CAP_C2;
        /**
         * Calculate geodesic scales <i>M12</i> and <i>M21</i>.
         **********************************************************************/
        public static readonly int GEODESICSCALE = 1 << 13 | CAP_C1 | CAP_C2;
        /**
         * Calculate Area <i>S12</i>.
         **********************************************************************/
        public static readonly int AREA = 1 << 14 | CAP_C4;
        /**
         * All capabilities, calculate everything.
         **********************************************************************/
        public static readonly int ALL = OUT_ALL | CAP_ALL;
    }
}
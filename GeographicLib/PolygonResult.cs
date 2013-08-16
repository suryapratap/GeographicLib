/**
 * Implementation of the net.sf.geographiclib.PolygonResult class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{

    /**
     * A container for the results from PolygonArea.
     **********************************************************************/
    public class PolygonResult
    {
        /**
         * The number of vertices in the polygon
         **********************************************************************/
        public int Num;
        /**
         * The Perimeter of the polygon or the length of the polyline (meters).
         **********************************************************************/
        public double Perimeter;
        /**
         * The Area of the polygon (meters<sup>2</sup>).
         **********************************************************************/
        public double Area;
        /**
         * Constructor
         * <p>
         * @param Num the number of vertices in the polygon.
         * @param Perimeter the Perimeter of the polygon or the length of the
         *   polyline (meters).
         * @param Area the Area of the polygon (meters<sup>2</sup>).
         **********************************************************************/
        public PolygonResult(int Num, double Perimeter, double Area)
        {
            this.Num = Num;
            this.Perimeter = Perimeter;
            this.Area = Area;
        }
    }
}
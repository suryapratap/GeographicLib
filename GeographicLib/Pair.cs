/**
 * Implementation of the net.sf.geographiclib.Pair class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{
    /// <summary>
    /// A pair of double precision numbers.
    /// This duplicates the C++ class {@code std::pair<double, double>}.
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// The First member of the pair.
        /// </summary>
        public double First;

        /// <summary>
        /// The Second member of the pair.
        /// </summary>
        public double Second;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="First">First the First member of the pair.</param>
        /// <param name="Second">Second the Second member of the pair.</param>
        public Pair(double First, double Second)
        {
            this.First = First;
            this.Second = Second;
        }
    }
}
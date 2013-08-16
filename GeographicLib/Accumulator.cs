/**
 * Implementation of the net.sf.geographiclib.Accumulator class
 *
 * Copyright (c) Charles Karney (2013) <charles@karney.com> and licensed
 * under the MIT/X11 License.  For more information, see
 * http://geographiclib.sourceforge.net/
 **********************************************************************/
namespace GeographicLib
{

    /// <summary>
    /// An accumulator for sums. 
    /// This allow many double precision numbers to be added together with twice the
    /// normal precision.  Thus the effective precision of the sum is 106 bits or
    /// about 32 decimal places.
    /// The implementation follows J. R. Shewchuk,
    /// <a href="http://dx.doi.org/10.1007/PL00009321"> Adaptive Precision
    /// Floating-Point Arithmetic and Fast Robust Geometric Predicates</a>,
    /// Discrete & Computational Geometry 18(3) 305&ndash;363 (1997).
    /// In the documentation of the member functions, <i>sum</i> stands for the value
    /// currently held in the accumulator.
    /// </summary>
    public class Accumulator
    {
        /// <summary>
        /// _s + _t accumulators for the sum.
        /// </summary>
        private double _s, _t;

        /// <summary>
        ///  Construct from a double.
        /// </summary>
        /// <param name="y">set <i>sum</i> = <i>y</i>.</param>
        public Accumulator(double y)
        {
            _s = y;
            _t = 0;
        }

        /// <summary>
        /// Construct from another Accumulator.
        /// </summary>
        /// <param name="a">set <i>sum</i> = <i>a</i>.</param>
        public Accumulator(Accumulator a)
        {
            _s = a._s;
            _t = a._t;
        }

        /// <summary>
        /// Set the value to a double.
        /// </summary>
        /// <param name="y">set <i>sum</i> = <i>y</i>.</param>
        public void Set(double y)
        {
            _s = y;
            _t = 0;
        }

        /// <summary>
        ///  Return the value
        /// </summary>
        /// <returns><i>sum</i>.</returns>
        public double Sum()
        {
            return _s;
        }

        /// <summary>
        /// Return the result of adding a number to <i>sum</i> (but don't change <i>sum</i>).
        /// </summary>
        /// <param name="y">the number to be added to the sum.</param>
        /// <returns><i>sum</i> + <i>y</i>.</returns>
        public double Sum(double y)
        {
            Accumulator a = new Accumulator(this);
            a.Add(y);
            return a._s;
        }

        /// <summary>
        /// Add a number to the accumulator.
        /// </summary>
        /// <param name="y">Set <i>sum</i> += <i>y</i>.</param>
        public void Add(double y)
        {
            // Here's Shewchuk's solution...
            double u;                       // hold exact sum as [s, t, u]
            // Accumulate starting at least significant end
            {
                Pair r = GeoMath.sum(y, _t);
                y = r.First;
                u = r.Second;
            }
            {
                Pair r = GeoMath.sum(y, _s);
                _s = r.First;
                _t = r.Second;
            }
            // Start is _s, _t decreasing and non-adjacent.  Sum is now (s + t + u)
            // exactly with s, t, u non-adjacent and in decreasing order (except for
            // possible zeros).  The following code tries to normalize the result.
            // Ideally, we want _s = round(s+t+u) and _u = round(s+t+u - _s).  The
            // following does an approximate job (and maintains the decreasing
            // non-adjacent property).  Here are two "failures" using 3-bit floats:
            //
            // Case 1: _s is not equal to round(s+t+u) -- off by 1 ulp
            // [12, -1] - 8 -> [4, 0, -1] -> [4, -1] = 3 should be [3, 0] = 3
            //
            // Case 2: _s+_t is not as close to s+t+u as it shold be
            // [64, 5] + 4 -> [64, 8, 1] -> [64,  8] = 72 (off by 1)
            //                    should be [80, -7] = 73 (exact)
            //
            // "Fixing" these problems is probably not worth the expense.  The
            // representation inevitably leads to small errors in the accumulated
            // values.  The additional errors illustrated here amount to 1 ulp of the
            // less significant word during each addition to the Accumulator and an
            // additional possible error of 1 ulp in the reported sum.
            //
            // Incidentally, the "ideal" representation described above is not
            // canonical, because _s = round(_s + _t) may not be true.  For example,
            // with 3-bit floats:
            //
            // [128, 16] + 1 -> [160, -16] -- 160 = round(145).
            // But [160, 0] - 16 -> [128, 16] -- 128 = round(144).
            //
            if (_s == 0)              // This implies t == 0,
                _s = u;                 // so result is u
            else
                _t += u;                // otherwise just accumulate u to t.
        }




        /// <summary>
        /// Negate an accumulator.
        /// <p>
        /// Set <i>sum</i> = &minus;<i>sum</i>.
        /// </summary>
        public void Negate()
        {
            _s = -_s;
            _t = -_t;
        }
    }
}
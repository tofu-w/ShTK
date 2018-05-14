using System;

namespace ShTK.Maths
{
    /// <summary>
    /// Miscellaneous maths functions for general use
    /// </summary>
    public static class MathsUtils
    {
        /// <summary>
        /// Get the percentage of a value.
        /// The equivalent of using a percentage value for a width tag in html
        /// </summary>
        /// <param name="perc"></param>
        /// <param name="whole"></param>
        /// <returns></returns>
        public static float GetProportional(float perc, float whole)
        {
            return perc / 100 * whole;
        }
    }
}

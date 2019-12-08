using System.Collections.Generic;

namespace RandomList.Core
{
    /// <summary>
    /// RandomList Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts to a RandomList
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">IEnumberable collection</param>
        /// <returns>The RandomList instance</returns>
        public static RandomList<T> ToRandomList<T>(this IEnumerable<T> collection)
        {
            return new RandomList<T>(collection);
        }
    }
}
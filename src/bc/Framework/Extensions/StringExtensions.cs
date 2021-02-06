using System;
namespace bc.Framework.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Compares this value with a specified <see cref="string"/> value and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string, accounting for null preceding non-null values
        /// </summary>
        /// <param name="s">this value</param>
        /// <param name="other">the string to compare to this value</param>
        /// <returns>A 32-bit signed integer that indicates whether this value precedes, follows, or appears in the same position in the sort order as <paramref name="other"/>
        /// <para>Value – Condition</para>
        /// <para>Less than zero – This value precedes <paramref name="other"/></para>
        /// <para>Zero – This value has the same position in the sort order as <paramref name="other"/></para>
        /// <para>Greater than zero – This value follows <paramref name="other"/> or <paramref name="other"/> is null</para></returns>
        public static int NullSafeCompareTo(this string s, string other) => ( s == null && other == null) ? 0 : ( s == null && other != null) ? -(other.CompareTo(s)) : s.CompareTo(other);
    }
}
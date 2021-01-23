using System;

namespace bc.Framework.Language
{
    /// <summary>
    /// A production rule
    /// </summary>
    public struct Production : IComparable<Production>, IEquatable<Production>
    {
        /// <summary>
        /// The production head
        /// </summary>
        /// <value></value>
        public string Head { get; init; }

        /// <summary>
        /// The production body
        /// </summary>
        /// <value></value>
        public string Body { get; init; }

        /// <summary>
        /// The production probability
        /// </summary>
        /// <value></value>
        public double Probability { get; init; }

        /// <summary>
        /// Compares this <see cref="Production"/> with a specified <see cref="Production"/> and indicates whether this value precedes, follows, or appears in the same position in the sort order as the specified value
        /// </summary>
        /// <param name="other"></param>
        /// <returns>A 32-bit signed integer that indicates whether this value precedes, follows, or appears in the same position in the sort order as the <paramref name="other"/> value.
        /// </returns>
        public int CompareTo(Production other)
        {
            var comp = Head.CompareTo(other.Head);
            if (comp != 0) return comp;
            comp = Body.CompareTo(other.Body);
            if (comp != 0) return comp;
            // else
            return Probability.CompareTo(other.Probability);
        }

        /// <summary>
        /// Determines whether this value and another <see cref="Production"/> value have the same value.
        /// </summary>
        /// <param name="other">the <see cref="Production"/> value to compare with this value</param>
        /// <returns><c>true</c> if <paramref name="other"/> is equal to this value; otherwise, false</returns>
        public bool Equals(Production other) => Head.Equals(other.Head) && Body.Equals(other.Body) && Probability.Equals(other.Probability);

        /// <summary>
        /// Compares two <see cref="Production"/> values for equality
        /// </summary>
        /// <param name="lhs">the first value</param>
        /// <param name="rhs">the second value</param>
        /// <returns><c>true</c> if <paramref name="lhs"/> and <paramref name="rhs"/> are equal values; otherwise, <c>false</c></returns>
        public static bool operator ==(Production lhs, Production rhs) => lhs.Head.Equals(rhs.Head) && lhs.Body.Equals(rhs.Body) && lhs.Probability.Equals(rhs.Probability);

        /// <summary>
        /// Compares two <see cref="Production"/> values for inequality
        /// </summary>
        /// <param name="lhs">the first value</param>
        /// <param name="rhs">the second value</param>
        /// <returns><c>true</c> if <paramref name="lhs"/> and <paramref name="rhs"/> are not equal values; otherwise, <c>false</c></returns>
        public static bool operator !=(Production lhs, Production rhs) => !lhs.Head.Equals(rhs.Head) || !lhs.Body.Equals(rhs.Body) || !lhs.Probability.Equals(rhs.Probability);

        /// <summary>
        /// Determines whether one <see cref="Production"/> value is less than another <see cref="Production"/> value
        /// </summary>
        /// <param name="left">the first value</param>
        /// <param name="right">the second value</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c></returns>
        public static bool operator <(Production left, Production right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Determines whether one <see cref="Production"/> value is greater than another <see cref="Production"/> value
        /// </summary>
        /// <param name="left">the first value</param>
        /// <param name="right">the second value</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c></returns>
        public static bool operator >(Production left, Production right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Determines whether one <see cref="Production"/> value is less than or equal another <see cref="Production"/> value
        /// </summary>
        /// <param name="left">the first value</param>
        /// <param name="right">the second value</param>
        /// <returns><c>true</c> if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, <c>false</c></returns>
        public static bool operator <=(Production left, Production right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Determines whether one <see cref="Production"/> value is greater than or equal another <see cref="Production"/> value
        /// </summary>
        /// <param name="left">the first value</param>
        /// <param name="right">the second value</param>
        /// <returns><c>true</c> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, <c>false</c></returns>
        public static bool operator >=(Production left, Production right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Determines whether this value and another <see cref="Object"/> are equal values
        /// </summary>
        /// <param name="obj">the other object</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a <see cref="Production"/> value equal to this value; otherwise, <c>false</c></returns>
        public override bool Equals(object obj) => obj is Production other && this.Equals(other);

        /// <summary>
        /// Calculates the hash code for a <see cref="Production"/> value
        /// </summary>
        /// <returns>the hash code for this value</returns>
        public override int GetHashCode() => (Head, Body, Probability).GetHashCode();
    }
}
using System;
using bc.Framework.Extensions;

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
        /// The production next context; the string that must immediately follow <see cref="Head"/> in order for the production to apply; empty in context free gammars
        /// </summary>
        /// <value></value>
        public string Next { get; init; }

        /// <summary>
        /// The production precendent context, that is, the string that must preced <see cref="Head"/> in order for the production to apply; empty in context free gammars
        /// </summary>
        /// <value></value>
        public string Precedent { get; init; }

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
            var comp = Head.NullSafeCompareTo(other.Head);
            if (comp != 0) return comp;

            comp = Precedent.NullSafeCompareTo(other.Precedent);
            if (comp != 0) return comp;

            comp = Next.NullSafeCompareTo(other.Next);
            if (comp != 0) return comp;

            comp = Body.NullSafeCompareTo(other.Body);
            if (comp != 0) return comp;

            // else
            return Probability.CompareTo(other.Probability);
        }

        //private static int NullSafeCompareTo(string lhs, string rhs) => ( lhs == null && rhs == null) ? 0 : ( lhs == null && rhs != null) ? -(rhs.CompareTo(lhs)) : lhs.CompareTo(rhs);

        /// <summary>
        /// Determines whether this value and another <see cref="Production"/> value have the same value.
        /// </summary>
        /// <param name="other">the <see cref="Production"/> value to compare with this value</param>
        /// <returns><c>true</c> if <paramref name="other"/> is equal to this value; otherwise, false</returns>
        public bool Equals(Production other) =>
            Head == other.Head &&
            Body == other.Body &&
            Precedent == other.Precedent &&
            Next == other.Next &&
            Probability.Equals(other.Probability);

        /// <summary>
        /// Determines if this value matches a given input at a specified location
        /// </summary>
        /// <param name="input">the string to check against this <see cref="Production"/></param>
        /// <param name="position">the position within <paramref name="input"/> to check against</param>
        /// <returns>true if this <see cref="Production"/> matches <paramref name="input"/> at <paramref name="position"/>; otherwise, false</returns>
        public bool Matches(string input, int position)
        {
            if (input == null) return false;
            if (Head == null || Head == "") return false;

            if (input.Length - position < Head.Length)
                return false;

            // if head doesn't match input at the position, return false
            if (!input.Substring(position, Head.Length).Equals(Head))
                return false;

            if (Precedent != null)
            {
                // check that there's space
                if (position < Precedent.Length) return false;
                if (Precedent.Length > 0 && !Precedent.Equals(input.Substring(position - Precedent.Length, Precedent.Length)))
                    return false;
            }

            if (Next != null)
            {
                // check that there's space
                if (input.Length - position - Head.Length < Next.Length) return false;
                if (Next?.Length > 0 && !Next.Equals(input.Substring(position + Head.Length, Next.Length)))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Compares two <see cref="Production"/> values for equality
        /// </summary>
        /// <param name="lhs">the first value</param>
        /// <param name="rhs">the second value</param>
        /// <returns><c>true</c> if <paramref name="lhs"/> and <paramref name="rhs"/> are equal values; otherwise, <c>false</c></returns>
        public static bool operator ==(Production lhs, Production rhs) =>
            lhs.Head == rhs.Head &&
            lhs.Body == rhs.Body &&
            lhs.Precedent == rhs.Precedent &&
            lhs.Next == rhs.Next &&
            lhs.Probability == rhs.Probability;

        /// <summary>
        /// Compares two <see cref="Production"/> values for inequality
        /// </summary>
        /// <param name="lhs">the first value</param>
        /// <param name="rhs">the second value</param>
        /// <returns><c>true</c> if <paramref name="lhs"/> and <paramref name="rhs"/> are not equal values; otherwise, <c>false</c></returns>
        public static bool operator !=(Production lhs, Production rhs) =>
            lhs.Head != rhs.Head ||
            lhs.Body != rhs.Body ||
            lhs.Precedent != rhs.Precedent ||
            lhs.Next != rhs.Next ||
            lhs.Probability != rhs.Probability;

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
        public override int GetHashCode() => (Head, Body, Precedent, Next, Probability).GetHashCode();

        public override string ToString()
        {
            var text = "";
            if (Precedent?.Length > 0)
            {
                text += $"{Precedent} < ";
            }
            text += Head;
            if (Next?.Length > 0)
            {
                text += $" > {Next}";
            }
            if (Probability != 1.0)
            {
                text += $" ({Probability.ToString("N2")})";
            }
            text += $" → {Body}";
            return text;
        }
    }
}
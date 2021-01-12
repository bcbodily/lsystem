using System;

namespace bc.Framework.Grammar
{
    /// <summary>
    /// A production rule
    /// </summary>
    public struct Production : IComparable<Production>, IEquatable<Production>
    {
        /// <summary>
        /// backing member for <see cref="Production.Predecessor"/>
        /// </summary>
        private readonly string predecessor;

        /// <summary>
        /// backing member for <see cref="Production.Successor"/>
        /// </summary>
        private readonly string successor;

        /// <summary>
        /// The production predecessor
        /// </summary>
        /// <value></value>
        public string Predecessor
        {
            get => predecessor;
            init
            {
                if (value == "")
                {
                    throw new ArgumentException($"{nameof(this.Predecessor)} is empty; {nameof(this.Predecessor)} must be non-empty.");
                }
                predecessor = value;
            }
        }

        /// <summary>
        /// The production successor
        /// </summary>
        /// <value></value>
        public string Successor
        {
            get => successor;

            init
            {
                if (value == "")
                {
                    throw new ArgumentException($"{nameof(this.Successor)} is empty; {nameof(this.Successor)} must be non-empty.");
                }
                successor = value;
            }
        }

        /// <summary>
        /// Compares this <see cref="Production"/> with a specified <see cref="Production"/> and indicates whether this value precedes, follows, or appears in the same position in the sort order as the specified value
        /// </summary>
        /// <param name="other"></param>
        /// <returns>A 32-bit signed integer that indicates whether this value precedes, follows, or appears in the same position in the sort order as the <paramref name="other"/> value.
        /// </returns>
        public int CompareTo(Production other)
        {
            var comp = Predecessor.CompareTo(other.Predecessor);
            if (comp != 0)
                return comp;

            return Successor.CompareTo(other.Successor);
        }

        /// <summary>
        /// Determines whether this value and another <see cref="Production"/> value have the same value.
        /// </summary>
        /// <param name="other">the <see cref="Production"/> value to compare with this value</param>
        /// <returns><c>true</c> if <paramref name="other"/> is equal to this value; otherwise, false</returns>
        public bool Equals(Production other) => Predecessor.Equals(other.Predecessor) && Successor.Equals(other.Successor);
    }
}
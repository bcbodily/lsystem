using System;
namespace bc.Framework.Language.Phonetics
{
    /// <summary>
    /// A distinct speech sound
    /// </summary>
    public struct Phone : IEquatable<Phone>, IComparable<Phone>
    {
        /// <summary>
        /// The symbol that represents this phone
        /// </summary>
        /// <value>the symbol that represents this phone</value>
        public string Symbol { get; init; }

        /// <summary>
        /// Creates a new phone with a specified symbol
        /// </summary>
        /// <param name="symbol">the symbol that specifies this phone</param>
        public Phone(string symbol) { Symbol = symbol; }

        /// <summary>
        /// Returns whether another phone is equal to this phone
        /// </summary>
        /// <param name="other">the other phone</param>
        /// <returns>true if the other Phone is equal to this Phone; otherwise, false</returns>
        public bool Equals(Phone other) =>
            this == other;

        /// <summary>
        /// Returns whether another object is equal to this phone
        /// </summary>
        /// <param name="obj">the other object</param>
        /// <returns>true if the other object is a Phone equal to this Phone; otherwise, false</returns>
        public override bool Equals(object obj) =>
            obj is Phone other &&
            this == other;

        /// <summary>
        /// Gets a consistent hash code for this Phone
        /// </summary>
        /// <returns>a consistent hash code for this Phone</returns>
        public override int GetHashCode() =>
            Symbol.GetHashCode();

        /// <summary>
        /// Gets a string representation of this phone
        /// </summary>
        /// <returns>a string representation of this phone</returns>
        public override string ToString() =>
            $"[{Symbol}]";

        /// <summary>
        /// Returns a value indicating the relative order of another phone in relation to this phone
        /// </summary>
        /// <param name="other">the other phone</param>
        /// <returns>if the other phone comes before this phone, a value less than zero; if the other phone comes after this phone, a value greater than zero; otherwise, zero</returns>
        public int CompareTo(Phone other) => Symbol.CompareTo(other.Symbol);

        /// <summary>
        /// Returns whether two phones are equal
        /// </summary>
        /// <param name="lhs">the first Phone</param>
        /// <param name="rhs">the second Phone</param>
        /// <returns>true if the two phones are equal; otherwise, false</returns>
        public static bool operator ==(Phone lhs, Phone rhs) =>
            lhs.Symbol == rhs.Symbol;

        /// <summary>
        /// Returns whether two phones are not equal
        /// </summary>
        /// <param name="lhs">the first Phone</param>
        /// <param name="rhs">the second Phone</param>
        /// <returns>true if the two phones are not equal; otherwise, false</returns>
        public static bool operator !=(Phone lhs, Phone rhs) =>
            lhs.Symbol != rhs.Symbol;

        /// <summary>
        /// Creates a new <see cref="Phone"/> value
        /// </summary>
        /// <param name="s">a string to assign to <see cref="Phone.Symbol"/></param>
        public static implicit operator Phone(string s) => new Phone(s);
    }
}
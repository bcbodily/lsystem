using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bc.Framework.Extensions
{
    /// <summary>
    /// Unit tests for <see cref="StringExtensions"/>
    /// </summary>
    [TestClass]
    public class StringExtensionsTests
    {
        /// <summary>
        /// Verifies <see cref="StringExtensions.NullSafeCompareTo(string, string)"/>, when this string is null and the other string is null, properly returns zero
        /// </summary>
        [TestMethod]
        public void NullSafeCompareTo_this_is_null_other_is_null_returns_zero()
        {
            string lhs = null;
            string rhs = null;

            Assert.IsNull(lhs);
            Assert.IsNull(rhs);

            Assert.IsTrue(lhs.NullSafeCompareTo(rhs) == 0);
        }

        /// <summary>
        /// Verifies <see cref="StringExtensions.NullSafeCompareTo(string, string)"/>, when this string is null and the other string is not null, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void NullSafeCompareTo_this_is_null_other_isNot_null_returns_negative()
        {
            string lhs = null;
            string rhs = "";

            Assert.IsNull(lhs);
            Assert.IsNotNull(rhs);

            Assert.IsTrue(lhs.NullSafeCompareTo(rhs) < 0);
        }

        /// <summary>
        /// Verifies <see cref="StringExtensions.NullSafeCompareTo(string, string)"/>, when this string is not null and the other string is null, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void NullSafeCompareTo_this_isNot_null_other_is_null_returns_positive()
        {
            string lhs = "";
            string rhs = null;

            Assert.IsNotNull(lhs);
            Assert.IsNull(rhs);

            Assert.IsTrue(lhs.NullSafeCompareTo(rhs) > 0);
        }

        /// <summary>
        /// Verifies <see cref="StringExtensions.NullSafeCompareTo(string, string)"/>, when this string is not null and the other string is not null, properly returns the result of calling <see cref="string.CompareTo(string?)"/> on this value with the other value as an argument
        /// </summary>
        [DataTestMethod]
        [DataRow("a", "b")]
        [DataRow("b", "a")]
        [DataRow("a", "")]
        [DataRow("", "b")]
        [DataRow("", "")]
        public void NullSafeCompareTo_this_isNot_null_other_isNot_null_returns_CompareTo(string lhs, string rhs)
        {
            Assert.IsNotNull(lhs);
            Assert.IsNotNull(rhs);

            var expected = lhs.CompareTo(rhs);
            var actual = lhs.NullSafeCompareTo(rhs);

            Assert.AreEqual(expected, actual);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bc.Framework.Grammar
{
    /// <summary>
    /// Unit tests for <see cref="Production"/>
    /// </summary>
    [TestClass]
    public class ProductionTests
    {
        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Predecessor"/> and <see cref="Production.Successor"/> values are both equal, properly returns <c>0</c>
        /// </summary>
        public void CompareTo_values_are_equal_returns_zero()
        {
            var predessor = "a";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            Assert.AreEqual(prod2, prod1);

            var expected = 0;
            var actual = prod1.CompareTo(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Predecessor"/> values are equal and the <see cref="Production.Successor"/> value of this value is greater than the <see cref="Production.Successor"/> value of the other value, properly returns a value greater than zero
        /// </summary>
        public void CompareTo_Predessor_values_are_equal_and_Successor_value_is_greater_returns_positive()
        {
            var predessor = "a";
            var successor1 = "c";
            var successor2 = "b";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor1
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor2
            };

            Assert.AreEqual(prod2, prod1);
            Assert.IsTrue(prod1.Successor.CompareTo(prod2.Successor) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Predecessor"/> values are equal and the <see cref="Production.Successor"/> value of this value is less, properly returns a value less than zero
        /// </summary>
        public void CompareTo_Predessor_values_are_equal_and_Successor_value_is_lesser_returns_negative()
        {
            var predessor = "a";
            var successor1 = "b";
            var successor2 = "c";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor1
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor2
            };

            Assert.AreEqual(prod2, prod1);
            Assert.IsTrue(prod1.Successor.CompareTo(prod2.Successor) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when the <see cref="Production.Predecessor"/> value of this value is greater, properly returns a value greater than zero
        /// </summary>
        public void CompareTo_Predessor_values_is_greater_returns_positive()
        {
            var predessor1 = "b";
            var predessor2 = "a";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.IsTrue(prod1.Predecessor.CompareTo(prod2.Predecessor) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when the <see cref="Production.Predecessor"/> value of this value is less, properly returns a value less than zero
        /// </summary>
        public void CompareTo_Predessor_values_is_lesser_returns_negative()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.IsTrue(prod1.Predecessor.CompareTo(prod2.Predecessor) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Predecessor"/> and <see cref="Production.Successor"/> values are equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Equals_Predecessors_and_Successors_are_Equal_returns_true()
        {
            var predessor = "a";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            Assert.AreEqual(prod1.Predecessor, prod2.Predecessor);
            Assert.AreEqual(prod1.Successor, prod2.Successor);

            var expected = true;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Predecessor"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Equals_Predecessors_areNot_equal_returns_false()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.AreNotEqual(prod1.Predecessor, prod2.Predecessor);

            var expected = false;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Successor"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Equals_Successors_areNot_equal_returns_false()
        {
            var predessor = "a";
            var successor1 = "b";
            var successor2 = "c";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor1
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor2
            };

            Assert.AreNotEqual(prod1.Successor, prod2.Successor);

            var expected = false;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is null, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_null_returns_false()
        {
            var prod = new Production { Predecessor = "a", Successor = "b" };
            Object other = null;

            Assert.IsNull(other);

            var expected = false;
            var actual = prod.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is an equal <see cref="Production"/>, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_equal_Production_returns_true()
        {
            var predessor = "a";
            var successor = "b";

            var production = new Production { Predecessor = predessor, Successor = successor };
            Object other = new Production { Predecessor = predessor, Successor = successor };

            Assert.AreEqual(production, (Production)other);

            var expected = true;
            var actual = production.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is a <see cref="Production"/> with an different <see cref="Production.Predecessor"/>, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_Production_with_different_Predessor_returns_false()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var production = new Production { Predecessor = predessor1, Successor = successor };
            Object other = new Production { Predecessor = predessor2, Successor = successor };

            Assert.AreNotEqual(production.Predecessor, ((Production)other).Predecessor);

            var expected = false;
            var actual = production.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is a <see cref="Production"/> with an different <see cref="Production.Successor"/>, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_Production_with_different_Successor_returns_false()
        {
            var predessor = "a";
            var successor1 = "b";
            var successor2 = "c";

            var production = new Production { Predecessor = predessor, Successor = successor1 };
            Object other = new Production { Predecessor = predessor, Successor = successor2 };

            Assert.AreNotEqual(production.Successor, ((Production)other).Successor);

            var expected = false;
            var actual = production.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is not a <see cref="Production"/>, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_isNot_Production_returns_false()
        {
            var prod = new Production { Predecessor = "a", Successor = "b" };
            String other = "";

            Assert.IsNotInstanceOfType(other, typeof(Production));

            var expected = false;
            var actual = prod.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.GetHashCode"/> properly returns the same hash code for equal values
        /// </summary>
        /// <param name="predessor">a predessor value</param>
        /// <param name="successor">a successor value</param>
        [DataTestMethod]
        [DataRow("a", "b")]
        [DataRow("c", "d")]
        public void GetHashCode_equal_values_return_equal_hashcodes(string predessor, string successor)
        {
            var prod1 = new Production { Predecessor = predessor, Successor = successor };
            var prod2 = new Production { Predecessor = predessor, Successor = successor };

            Assert.AreEqual(prod2, prod1);

            Assert.AreEqual(prod1.GetHashCode(), prod2.GetHashCode());
        }

        /// <summary>
        /// Verifies that the equality operator for <see cref="Production"/>, when both <see cref="Production.Predecessor"/> and <see cref="Production.Successor"/> values are equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Predecessor_and_Successor_are_equal_returns_true()
        {
            var predessor = "a";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            Assert.AreEqual(prod1.Predecessor, prod2.Predecessor);
            Assert.AreEqual(prod1.Successor, prod2.Successor);

            var expected = true;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the equality operator for <see cref="Production"/>, when <see cref="Production.Predecessor"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Predecessor_isNot_equal_returns_false()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.AreNotEqual(prod1.Predecessor, prod2.Predecessor);

            var expected = false;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the equality operator for <see cref="Production"/>, when <see cref="Production.Successor"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Successor_isNot_equal_returns_false()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.AreNotEqual(prod1.Predecessor, prod2.Predecessor);

            var expected = false;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the inequality operator for <see cref="Production"/>, when both <see cref="Production.Predecessor"/> and <see cref="Production.Successor"/> values are equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Predecessor_and_Successor_are_equal_returns_false()
        {
            var predessor = "a";
            var successor = "b";

            var prod1 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor,
                Successor = successor
            };

            Assert.AreEqual(prod1.Predecessor, prod2.Predecessor);
            Assert.AreEqual(prod1.Successor, prod2.Successor);

            var expected = false;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the inequality operator for <see cref="Production"/>, when <see cref="Production.Predecessor"/> values are not equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Predecessor_isNot_equal_returns_true()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.AreNotEqual(prod1.Predecessor, prod2.Predecessor);

            var expected = true;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the inequality operator for <see cref="Production"/>, when <see cref="Production.Successor"/> values are not equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Successor_isNot_equal_returns_true()
        {
            var predessor1 = "a";
            var predessor2 = "b";
            var successor = "c";

            var prod1 = new Production
            {
                Predecessor = predessor1,
                Successor = successor
            };

            var prod2 = new Production
            {
                Predecessor = predessor2,
                Successor = successor
            };

            Assert.AreNotEqual(prod1.Predecessor, prod2.Predecessor);

            var expected = true;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the <see cref="Production.Predecessor"/> initializer, when the initial value is empty, properly throws an <see cref="ArgumentException"/>
        /// </summary>
        [TestMethod]
        public void Predecessor_initValue_is_empty_throws_ArgumentException()
        {
            var predecessor = "";
            var successor = "A";

            Assert.IsTrue(predecessor == "");

            Assert.ThrowsException<ArgumentException>(() => new Production
            {
                Predecessor = predecessor,
                Successor = successor
            });
        }

        /// <summary>
        /// Verifies the <see cref="Production.Predecessor"/> initializer, when the initial value is not empty, properly assigns <see cref="Production.Predecessor"/> to the specified value
        /// </summary>
        /// <param name="predessor">an initial value</param>
        [DataTestMethod]
        [DataRow("A")]
        [DataRow("B")]
        public void Predecessor_initValue_isNot_empty_assigns_init_value(string predessor)
        {
            var successor = "C";

            var expected = predessor;
            var actual = new Production
            {
                Predecessor = predessor,
                Successor = successor
            }.Predecessor;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the <see cref="Production.Successor"/> initializer, when the initial value is empty, properly throws an <see cref="ArgumentException"/>
        /// </summary>
        [TestMethod]
        public void Successor_initValue_is_empty_throws_ArgumentException()
        {
            var predecessor = "A";
            var successor = "";

            Assert.IsTrue(successor == "");

            Assert.ThrowsException<ArgumentException>(() => new Production
            {
                Predecessor = predecessor,
                Successor = successor
            });
        }

        /// <summary>
        /// Verifies the <see cref="Production.Successor"/> initializer, when the initial value is not empty, properly assigns <see cref="Production.Successor"/> to the specified value
        /// </summary>
        /// <param name="successor">an initial value</param>
        [DataTestMethod]
        [DataRow("A")]
        [DataRow("B")]
        public void Successor_initValue_isNot_empty_assigns_init_value(string successor)
        {
            var predessor = "C";

            var expected = successor;
            var actual = new Production
            {
                Predecessor = predessor,
                Successor = successor
            }.Successor;

            Assert.AreEqual(expected, actual);
        }
    }
}

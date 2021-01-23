using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace bc.Framework.Language
{
    /// <summary>
    /// Unit tests for <see cref="Production"/>
    /// </summary>
    [TestClass]
    public class ProductionTests
    {
        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> and <see cref="Production.Body"/> and <see cref="Production.Probability"/> values are both equal, properly returns <c>0</c>
        /// </summary>
        [TestMethod]
        public void CompareTo_values_are_equal_returns_zero()
        {
            var predessor = "a";
            var successor = "b";
            var probability = 1.0;

            var prod1 = new Production
            {
                Head = predessor,
                Body = successor,
                Probability = probability
            };

            var prod2 = new Production
            {
                Head = predessor,
                Body = successor,
                Probability = probability
            };

            Assert.AreEqual(prod2, prod1);

            var expected = 0;
            var actual = prod1.CompareTo(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> and <see cref="Production.Body"/> values are equal and the <see cref="Production.Probability"/> value of this value is greater than the <see cref="Production.Probability"/> value of the other value, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_and_Body_values_are_equal_and_Probability_is_greater_returns_positive()
        {
            var head = "a";
            var body = "c";
            var probability1 = 1.0;
            var probability2 = 0.4;

            var prod1 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability1,
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability2
            };

            Assert.AreEqual(prod2.Head, prod1.Head);
            Assert.AreEqual(prod2.Body, prod1.Body);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> and <see cref="Production.Body"/> values are equal and the <see cref="Production.Probability"/> value of this value is lesser than the <see cref="Production.Probability"/> value of the other value, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_and_Body_values_are_equal_and_Probability_is_lesser_returns_negative()
        {
            var head = "a";
            var body = "c";
            var probability1 = 0.4;
            var probability2 = 1.0;

            var prod1 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability1,
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability2
            };

            Assert.AreEqual(prod2.Head, prod1.Head);
            Assert.AreEqual(prod2.Body, prod1.Body);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> values are equal and the <see cref="Production.Body"/> value of this value is greater than the <see cref="Production.Body"/> value of the other value, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_values_are_equal_and_Body_value_is_greater_returns_positive()
        {
            var head = "a";
            var body1 = "c";
            var body2 = "b";

            var prod1 = new Production
            {
                Head = head,
                Body = body1
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body2
            };

            Assert.AreEqual(prod2.Head, prod1.Head);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> values are equal and the <see cref="Production.Body"/> value of this value is less, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_values_are_equal_and_Body_value_is_lesser_returns_negative()
        {
            var head = "a";
            var body1 = "b";
            var body2 = "c";

            var prod1 = new Production
            {
                Head = head,
                Body = body1
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body2
            };

            Assert.AreEqual(prod2.Head, prod1.Head);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when the <see cref="Production.Head"/> value of this value is greater, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_values_is_greater_returns_positive()
        {
            var head1 = "b";
            var head2 = "a";
            var body = "b";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when the <see cref="Production.Head"/> value of this value is less, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_Head_values_is_lesser_returns_negative()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "b";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Head"/> and <see cref="Production.Body"/> and <see cref="Production.Probability"/> values are equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Equals_Head_and_Body_and_Probability_are_Equal_returns_true()
        {
            var head = "a";
            var body = "b";
            var probability = 0.5;

            var prod1 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability
            };

            Assert.AreEqual(prod1.Head, prod2.Head);
            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            var expected = true;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Head"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Equals_Heads_areNot_equal_returns_false()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.AreNotEqual(prod1.Head, prod2.Head);

            var expected = false;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Body"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Equals_Bodies_areNot_equal_returns_false()
        {
            var head = "a";
            var body1 = "b";
            var body2 = "c";

            var prod1 = new Production
            {
                Head = head,
                Body = body1
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body2
            };

            Assert.AreNotEqual(prod1.Body, prod2.Body);

            var expected = false;
            var actual = prod1.Equals(prod2);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(Production)"/>, when <see cref="Production.Probability"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Equals_Probabilities_areNot_equal_returns_false()
        {
            var head = "a";
            var body = "b";
            var probability1 = 0.5;
            var probability2 = 0.6;

            var prod1 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability1
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body,
                Probability = probability2
            };

            Assert.AreNotEqual(prod1.Probability, prod2.Probability);

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
            var prod = new Production { Head = "a", Body = "b" };
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
            var head = "a";
            var body = "b";
            var probability = 0.5;

            var production = new Production { Head = head, Body = body, Probability = probability };
            Object other = new Production { Head = head, Body = body, Probability = probability };

            Assert.AreEqual(production, (Production)other);

            var expected = true;
            var actual = production.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is a <see cref="Production"/> with an different <see cref="Production.Head"/>, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_Production_with_different_Head_returns_false()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var production = new Production { Head = head1, Body = body };
            Object other = new Production { Head = head2, Body = body };

            Assert.AreNotEqual(production.Head, ((Production)other).Head);

            var expected = false;
            var actual = production.Equals(other);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Equals(object)"/>, when the other object is a <see cref="Production"/> with an different <see cref="Production.Body"/>, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void EqualsObject_other_is_Production_with_different_Body_returns_false()
        {
            var head = "a";
            var body1 = "b";
            var body2 = "c";

            var production = new Production { Head = head, Body = body1 };
            Object other = new Production { Head = head, Body = body2 };

            Assert.AreNotEqual(production.Body, ((Production)other).Body);

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
            var prod = new Production { Head = "a", Body = "b" };
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
            var prod1 = new Production { Head = predessor, Body = successor };
            var prod2 = new Production { Head = predessor, Body = successor };

            Assert.AreEqual(prod2, prod1);

            Assert.AreEqual(prod1.GetHashCode(), prod2.GetHashCode());
        }

        /// <summary>
        /// Verifies that the equality operator for <see cref="Production"/>, when both <see cref="Production.Head"/> and <see cref="Production.Body"/> values are equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Head_and_Body_are_equal_returns_true()
        {
            var head = "a";
            var body = "b";

            var prod1 = new Production
            {
                Head = head,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(prod1.Head, prod2.Head);
            Assert.AreEqual(prod1.Body, prod2.Body);

            var expected = true;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the equality operator for <see cref="Production"/>, when <see cref="Production.Head"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Head_isNot_equal_returns_false()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.AreNotEqual(prod1.Head, prod2.Head);

            var expected = false;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the equality operator for <see cref="Production"/>, when <see cref="Production.Body"/> values are not equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Equality_Body_isNot_equal_returns_false()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.AreNotEqual(prod1.Head, prod2.Head);

            var expected = false;
            var actual = prod1 == prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies that the inequality operator for <see cref="Production"/>, when both <see cref="Production.Head"/> and <see cref="Production.Body"/> values are equal, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Head_and_Body_are_equal_returns_false()
        {
            var head = "a";
            var body = "b";

            var prod1 = new Production
            {
                Head = head,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(prod1.Head, prod2.Head);
            Assert.AreEqual(prod1.Body, prod2.Body);

            var expected = false;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the inequality operator for <see cref="Production"/>, when <see cref="Production.Head"/> values are not equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Head_isNot_equal_returns_true()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.AreNotEqual(prod1.Head, prod2.Head);

            var expected = true;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Verifies the greater than operator for <see cref="Production"/>, when the lhs value is equal to the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThan_lhs_is_equal_returns_false()
        {
            var head = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = head,
                Body = body
            };

            var rhs = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(lhs, rhs);

            var expected = false;
            var actual = lhs > rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the greater than operator for <see cref="Production"/>, when the lhs value is greater than the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThan_lhs_is_greaterThan_returns_true()
        {
            var headLhs = "b";
            var headRhs = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) > 0);

            var expected = true;
            var actual = lhs > rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the greater than operator for <see cref="Production"/>, when the lhs value is less than the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThan_lhs_is_lessThan_returns_false()
        {
            var headLhs = "a";
            var headRhs = "b";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) < 0);

            var expected = false;
            var actual = lhs > rhs;

            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Verifies the greater than or equal operator for <see cref="Production"/>, when the lhs value is equal to the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThanOrEqual_lhs_is_equal_returns_true()
        {
            var head = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = head,
                Body = body
            };

            var rhs = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(lhs, rhs);

            var expected = true;
            var actual = lhs >= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the greater than or equal operator for <see cref="Production"/>, when the lhs value is greater than the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThanOrEqual_lhs_is_greaterThan_returns_true()
        {
            var headLhs = "b";
            var headRhs = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) > 0);

            var expected = true;
            var actual = lhs >= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the greater than or equal operator for <see cref="Production"/>, when the lhs value is less than the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_GreaterThanOrEqual_lhs_is_lessThan_returns_false()
        {
            var headLhs = "a";
            var headRhs = "b";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) < 0);

            var expected = false;
            var actual = lhs >= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than operator for <see cref="Production"/>, when the lhs value is equal to the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThan_lhs_is_equal_returns_false()
        {
            var head = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = head,
                Body = body
            };

            var rhs = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(lhs, rhs);

            var expected = false;
            var actual = lhs < rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than operator for <see cref="Production"/>, when the lhs value is greater than the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThan_lhs_is_greaterThan_returns_false()
        {
            var headLhs = "b";
            var headRhs = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) > 0);

            var expected = false;
            var actual = lhs < rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than operator for <see cref="Production"/>, when the lhs value is less than the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThan_lhs_is_lessThan_returns_true()
        {
            var headLhs = "a";
            var headRhs = "b";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) < 0);

            var expected = true;
            var actual = lhs < rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than or equal operator for <see cref="Production"/>, when the lhs value is equal to the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThanOrEqual_lhs_is_equal_returns_true()
        {
            var head = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = head,
                Body = body
            };

            var rhs = new Production
            {
                Head = head,
                Body = body
            };

            Assert.AreEqual(lhs, rhs);

            var expected = true;
            var actual = lhs <= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than or equal operator for <see cref="Production"/>, when the lhs value is greater than the rhs value, properly returns <c>false</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThanOrEqual_lhs_is_greaterThan_returns_false()
        {
            var headLhs = "b";
            var headRhs = "a";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) > 0);

            var expected = false;
            var actual = lhs <= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the less than or equal operator for <see cref="Production"/>, when the lhs value is less than the rhs value, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_LessThanOrEqual_lhs_is_lessThan_returns_true()
        {
            var headLhs = "a";
            var headRhs = "b";
            var body = "b";

            var lhs = new Production
            {
                Head = headLhs,
                Body = body
            };

            var rhs = new Production
            {
                Head = headRhs,
                Body = body
            };

            Assert.IsTrue(lhs.CompareTo(rhs) < 0);

            var expected = true;
            var actual = lhs <= rhs;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the inequality operator for <see cref="Production"/>, when <see cref="Production.Body"/> values are not equal, properly returns <c>true</c>
        /// </summary>
        [TestMethod]
        public void Operator_Inequality_Body_isNot_equal_returns_true()
        {
            var head1 = "a";
            var head2 = "b";
            var body = "c";

            var prod1 = new Production
            {
                Head = head1,
                Body = body
            };

            var prod2 = new Production
            {
                Head = head2,
                Body = body
            };

            Assert.AreNotEqual(prod1.Head, prod2.Head);

            var expected = true;
            var actual = prod1 != prod2;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the <see cref="Production.Head"/> initializer, when the initial value is not empty, properly assigns <see cref="Production.Head"/> to the specified value
        /// </summary>
        /// <param name="head">an initial value</param>
        [DataTestMethod]
        [DataRow("A")]
        [DataRow("B")]
        public void Predecessor_initValue_isNot_empty_assigns_init_value(string head)
        {
            var body = "C";

            var expected = head;
            var actual = new Production
            {
                Head = head,
                Body = body
            }.Head;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies the <see cref="Production.Body"/> initializer, when the initial value is not empty, properly assigns <see cref="Production.Body"/> to the specified value
        /// </summary>
        /// <param name="body">an initial value</param>
        [DataTestMethod]
        [DataRow("A")]
        [DataRow("B")]
        public void Successor_initValue_isNot_empty_assigns_init_value(string body)
        {
            var predessor = "C";

            var expected = body;
            var actual = new Production
            {
                Head = predessor,
                Body = body
            }.Body;

            Assert.AreEqual(expected, actual);
        }
    }
}

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
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> is empty for both values and all other members are equal, properly returns 0
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_are_empty_all_other_equal_returns_zero()
        {
            var prod1 = new Production { Head = "", Body = "body", Precedent = "precedent", Next = "Next", Probability = 1.0 };
            var prod2 = new Production { Head = "", Body = "body", Precedent = "precedent", Next = "Next", Probability = 1.0 };

            Assert.IsTrue(prod1.Head == "");
            Assert.IsTrue(prod2.Head == "");

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) == 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> and <see cref="Production.Precedent"/> are equal to the other value, this <see cref="Production.Next"/> is after the other value, and all of the other members of this <see cref="Production"/> come before their corresponding members in the other value, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_and_Precedent_are_equal_Next_is_after_other_Next_and_other_values_are_before_returns_positive()
        {
            var prod1 = new Production { Head = "a", Body = "", Precedent = "a", Next = "a", Probability = 0.0 };
            var prod2 = new Production { Head = "a", Body = "b", Precedent = "a", Next = "", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) == 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) == 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) > 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) < 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> and <see cref="Production.Precedent"/> are equal to the other value, this <see cref="Production.Next"/> is before the other value, and all of the other members of this <see cref="Production"/> come after their corresponding members in the other value, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_and_Precedent_are_equal_Next_is_before_other_Next_and_other_values_are_after_returns_negative()
        {
            var prod1 = new Production { Head = "a", Body = "b", Precedent = "a", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = "a", Body = "", Precedent = "a", Next = "a", Probability = 0.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) == 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) == 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) < 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) > 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is equal to the other <see cref="Production.Head"/>, this <see cref="Production.Precedent"/> is after the other <see cref="Production.Precedent"/>, and all of the other members of this <see cref="Production"/> come before their corresponding members in the other value, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_are_equal_Precedent_is_after_other_Precedent_and_other_values_are_before_returns_positive()
        {
            var prod1 = new Production { Head = "a", Body = "", Precedent = "b", Next = "", Probability = 0.0 };
            var prod2 = new Production { Head = "a", Body = "b", Precedent = "a", Next = "b", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) == 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) > 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) < 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) < 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is equal to the other <see cref="Production.Head"/>, this <see cref="Production.Precedent"/> is before the other <see cref="Production.Precedent"/>, and all of the other members of this <see cref="Production"/> come after their corresponding members in the other value, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_are_equal_Precedent_is_before_other_Precedent_and_other_values_are_after_returns_negative()
        {
            var prod1 = new Production { Head = "a", Body = "b", Precedent = "", Next = "b", Probability = 1.0 };
            var prod2 = new Production { Head = "a", Body = "", Precedent = "b", Next = "", Probability = 0.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) == 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) < 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) > 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) > 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> is null for both values and all other members are equal, properly returns 0
        /// </summary>
        [TestMethod]
        public void CompareTo_both_Head_are_null_all_other_equal_returns_zero()
        {
            var prod1 = new Production { Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsNull(prod1.Head);
            Assert.IsNull(prod2.Head);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) == 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is empty and the other <see cref="Production.Head"/> is null, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_empty_and_other_Head_is_null_all_other_are_equal_returns_positive()
        {
            var prod1 = new Production { Head = "", Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = null, Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.AreEqual("", prod1.Head);
            Assert.IsNull(prod2.Head);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is empty and the other <see cref="Production.Head"/> is not empty, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_empty_and_other_Head_isNot_empty_all_other_are_equal_returns_negative()
        {
            var prod1 = new Production { Head = "", Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = "a", Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.Length == 0);
            Assert.IsTrue(prod2.Head.Length > 0);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is null and the other <see cref="Production.Head"/> is empty, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_null_and_other_Head_is_empty_all_other_are_equal_returns_negative()
        {
            var prod1 = new Production { Head = null, Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = "", Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsNull(prod1.Head);
            Assert.IsNotNull(prod2.Head);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is null and the other <see cref="Production.Head"/> is not empty, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_null_and_other_Head_isNot_empty_all_other_are_equal_returns_negative()
        {
            var prod1 = new Production { Head = null, Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = "a", Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsNull(prod1.Head);
            Assert.IsTrue(prod2.Head.Length > 0);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is not empty and the other <see cref="Production.Head"/> is empty, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_isNot_empty_and_other_Head_is_empty_all_other_are_equal_returns_positive()
        {
            var prod1 = new Production { Head = "a", Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = "", Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.Length > 0);
            Assert.IsTrue(prod2.Head.Length == 0);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> comes after the other <see cref="Production.Head"/> and all of the other members of this <see cref="Production"/> come after their corresponding members in the other value, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_after_other_Head_and_other_values_are_before_returns_positive()
        {
            var prod1 = new Production { Head = "b", Body = "", Precedent = "", Next = "", Probability = 0.0 };
            var prod2 = new Production { Head = "a", Body = "b", Precedent = "b", Next = "b", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) > 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) < 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) < 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) < 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) < 0);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> comes before the other <see cref="Production.Head"/> and all of the other members for this <see cref="Production"/> come before their corresponding members in the other value, properly returns a negative value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_is_before_other_Head_and_other_values_are_after_returns_negative()
        {
            var prod1 = new Production { Head = "a", Body = "b", Precedent = "b", Next = "b", Probability = 1.0 };
            var prod2 = new Production { Head = "b", Body = "", Precedent = "", Next = "", Probability = 0.0 };

            Assert.IsTrue(prod1.Head.CompareTo(prod2.Head) < 0);
            Assert.IsTrue(prod1.Body.CompareTo(prod2.Body) > 0);
            Assert.IsTrue(prod1.Precedent.CompareTo(prod2.Precedent) > 0);
            Assert.IsTrue(prod1.Next.CompareTo(prod2.Next) > 0);
            Assert.IsTrue(prod1.Probability.CompareTo(prod2.Probability) > 0);

            Assert.IsTrue(prod1.CompareTo(prod2) < 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when this <see cref="Production.Head"/> is not empty and the other <see cref="Production.Head"/> is null, properly returns a positive value
        /// </summary>
        [TestMethod]
        public void CompareTo_this_Head_isNot_empty_and_other_Head_is_null_all_other_are_equal_returns_positive()
        {
            var prod1 = new Production { Head = "a", Body = "", Precedent = "", Next = "", Probability = 1.0 };
            var prod2 = new Production { Head = null, Body = "", Precedent = "", Next = "", Probability = 1.0 };

            Assert.IsTrue(prod1.Head.Length > 0);
            Assert.IsNull(prod2.Head);

            Assert.AreEqual(prod1.Body, prod2.Body);
            Assert.AreEqual(prod1.Precedent, prod2.Precedent);
            Assert.AreEqual(prod1.Next, prod2.Next);
            Assert.AreEqual(prod1.Probability, prod2.Probability);

            Assert.IsTrue(prod1.CompareTo(prod2) > 0);
        }

        /// <summary>
        /// Verifies <see cref="Production.CompareTo(Production)"/>, when <see cref="Production.Head"/> and <see cref="Production.Body"/> and <see cref="Production.Precedent"/> and <see cref="Production.Next"/> and <see cref="Production.Probability"/> values are equal, properly returns <c>0</c>
        /// </summary>
        [TestMethod]
        public void CompareTo_values_are_equal_returns_zero()
        {
            var predessor = "a";
            var successor = "b";
            var precedent = "c";
            var next = "d";
            var probability = 1.0;

            var prod1 = new Production
            {
                Head = predessor,
                Body = successor,
                Next = next,
                Precedent = precedent,
                Probability = probability
            };

            var prod2 = new Production
            {
                Head = predessor,
                Body = successor,
                Next = next,
                Precedent = precedent,
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
        /// Verifies <see cref="Production.Matches(string, int)"/>, when the input is empty, properly returns false
        /// </summary>
        [TestMethod]
        public void Matches_contextfree_input_is_empty_returns_false()
        {
            var p = new Production();
            var input = "";
            var pos = 0;

            Assert.IsTrue(input.Length == 0);

            var expected = false;
            var actual = p.Matches(input, pos);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Matches(string, int)"/>, when <see cref="Production.Head"/> is empty, properly returns false
        /// </summary>
        [TestMethod]
        public void Matches_Head_is_empty_returns_false()
        {
            var p = new Production { Head = "" };
            var input = "any";
            var pos = 0;

            Assert.IsTrue(p.Head == "");

            var expected = false;
            var actual = p.Matches(input, pos);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Matches(string, int)"/>, when <see cref="Production.Head"/> is null, properly returns false
        /// </summary>
        [TestMethod]
        public void Matches_Head_is_null_returns_false()
        {
            var p = new Production();
            var input = "any";
            var pos = 0;

            Assert.IsNull(p.Head);

            var expected = false;
            var actual = p.Matches(input, pos);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Matches(string, int)"/>, when <see cref="Production.Head"/> is longer than the input, properly returns false
        /// </summary>
        /// <param name="head">the value to assigned to <see cref="Production.Head"/></param>
        /// <param name="input">the input value</param>
        [DataTestMethod]
        [DataRow("ab", "a")]
        [DataRow("abc", "ab")]
        public void Matches_Head_is_larger_than_input_returns_false(string head, string input)
        {
            var p = new Production { Head = head };
            var pos = 1;

            Assert.IsTrue(p.Head.Length > input.Length);

            var expected = false;
            var actual = p.Matches(input, pos);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Matches(string, int)"/>, when <see cref="Production.Head"/> matches the input at the specified position and has no precedent or next, properly returns true
        /// </summary>
        [TestMethod]
        public void Matches_Head_matches_input_at_position_and_is_context_free_returns_true()
        {
            var p = new Production { Head = "a" };
            var input = "bab";
            var pos = 1;

            Assert.AreEqual(p.Head, input.Substring(pos, 1));

            var expected = true;
            var actual = p.Matches(input, pos);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Verifies <see cref="Production.Matches(string, int)"/>, when the input is null, properly returns false
        /// </summary>
        [TestMethod]
        public void Matches_input_is_null_returns_false()
        {
            var p = new Production { Head = "a" };
            string input = null;

            Assert.IsNull(input);

            var expected = false;
            var actual = p.Matches(input, 1);

            Assert.AreEqual(expected, actual);
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

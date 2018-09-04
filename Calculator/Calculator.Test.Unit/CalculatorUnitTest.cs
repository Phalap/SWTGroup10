using NUnit.Framework;
using System;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorUnitTests
    {
        [Test]
        public void Add_Add2And4_Returns6()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Add(2, 4), Is.EqualTo(6));
        }


        [Test]
        public void Add_Add3And4_Returns7()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Add(3, 4), Is.EqualTo(7));
        }

        [Test]
        public void Subtract_Subtract3From4_Returns1()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Subtract(4, 3), Is.EqualTo(1));
        }

        [Test]
        public void Multiply_Multiply3And4_Returns12()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Multiply(3, 4), Is.EqualTo(12));
        }

        [Test]
        public void Power_Power3of2_Returns8()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Power(2, 3), Is.EqualTo(8));
        }

        [TestCase(2, 3, ExpectedResult = 5)]
        [TestCase(3, 5, ExpectedResult = 8)]
        [TestCase(3, 6, ExpectedResult = 9)]
        [TestCase(4, 4, ExpectedResult = 8)]
        public double AddWithTestCase_Add2Numbers_ReturnsResult(double x, double y)
        {
            var uut = new CalculatorClass.Calculator();

            return uut.Add(x, y);
        }

        //Test divide 2 positive numbers
        [Test]
        public void Divisions_divide9by3_returns3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Divide(9, 3), Is.EqualTo(3));
        }

        //Test divide negative by positive
        [Test]
        public void Divisions_divideMinus9by3_returnsMinus3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Divide(-9, 3), Is.EqualTo(-3));
        }

        //Test divide positive by negative
        [Test]
        public void Divisions_divide9byMinus3_returnsMinus3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Divide(9, -3), Is.EqualTo(-3));
        }

        //Test return decimal number
        [Test]
        public void Divisions_divide5by2_returnsMinus2point5()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Divide(5, 2), Is.EqualTo(2.5));
        }

        //Test for division by 0
        [Test]
        public void Divisions_divide5by0_returnsInfinity()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Divide(5, 0), Is.EqualTo(Double.PositiveInfinity));
        }

        #region test of overloads

        //Test addition of default accumulator and positive int
        [Test]
        public void Addition_add3toDefaultAccumulator_returns3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Add(3), Is.EqualTo(3));
        }

        //Test addition of default accumulator and negative int
        [Test]
        public void Addition_addMinus3toDefaultAccumulator_returnsMinus3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Add(-3), Is.EqualTo(-3));
        }

        //Test addition of initialized accumulator and positive int
        [Test]
        public void Addition_add3toInitializedAccumulator_returns6()
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(3); // Accumulator = 3 - Given that Add works as proposed.

            Assert.That(uut.Add(3), Is.EqualTo(6));
        }

        //Test addition of initialized accumulator and negative int
        [Test]
        public void Addition_addMinus3toInitializedAccumulator_returns1()
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(4); // Accumulator = 3 - Given that Add works as proposed.

            Assert.That(uut.Add(-3), Is.EqualTo(1));
        }

        //Test addition of default accumulator and positive decimal number
        [Test]
        public void Addition_add2point5toDefaultAccumulator_returns2point5()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Add(2.5), Is.EqualTo(2.5));
        }

        //Test subtraction of default accumulator and positive int
        [Test]
        public void Subtraction_subtract3fromDefaultAccumulator_returnsMinus3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Subtract(3), Is.EqualTo(-3));
        }

        //Test subtraction of default accumulator and negative int
        [Test]
        public void Subtraction_subtractMinus3fromDefaultAccumulator_returns3()
        {
            var uut = new CalculatorClass.Calculator();

            Assert.That(uut.Subtract(-3), Is.EqualTo(3));
        }

        //Test subtraction of initialized accumulator and positive int
        [Test]
        public void Subtraction_subtract3fromInitializedAccumulator_returns1()
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(4); // Accumulator = 4 - Given that Add works as proposed.

            Assert.That(uut.Subtract(3), Is.EqualTo(1));
        }

        //Test subtraction of initialized accumulator and negative int
        [Test]
        public void Subtraction_subtractMinus3fromInitializedAccumulator_returns1()
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(4); // Accumulator = 4 - Given that Add works as proposed.

            Assert.That(uut.Subtract(-3), Is.EqualTo(7));
        }

        //Test multiplication with uninitialized Accumulator
        [TestCase(2, ExpectedResult = 0)]
        [TestCase(-2, ExpectedResult = 0)]
        [TestCase(1.5, ExpectedResult = 0)]
        public double MultiplyWithTestCase_MultiplyWithUninitializedAccumulator_ReturnsResult(double Multiplicator)
        {
            var uut = new CalculatorClass.Calculator();

            return uut.Multiply(Multiplicator);
        }

        //Test multiplication with initialized Accumulator
        [TestCase(2, ExpectedResult = 8)]
        [TestCase(-2, ExpectedResult = -8)]
        [TestCase(1.5, ExpectedResult = 6)]
        public double MultiplyWithTestCase_MultiplyWithInitializedAccumulator_ReturnsResult(double Multiplicator)
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(4); // Accumulator = 4 - Given that Add works as proposed.

            return uut.Multiply(Multiplicator);
        }

        //Test division with uninitialized Accumulator
        [TestCase(2, ExpectedResult = 0)]
        [TestCase(-2, ExpectedResult = 0)]
        [TestCase(1.5, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = Double.NaN)]
        public double DivisionWithTestCase_MultiplyWithUninitializedAccumulator_ReturnsResult(double divisor)
        {
            var uut = new CalculatorClass.Calculator();

            return uut.Divide(divisor);
        }

        //Test multiplication with initialized Accumulator
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(-2, ExpectedResult = -2)]
        [TestCase(1.5, ExpectedResult = 4 / 1.5)]
        [TestCase(0, ExpectedResult = Double.PositiveInfinity)]
        public double DivisionWithTestCase_MultiplyWithInitializedAccumulator_ReturnsResult(double divisor)
        {
            var uut = new CalculatorClass.Calculator();

            uut.Add(4); // Accumulator = 4 - Given that Add works as proposed.

            return uut.Divide(divisor);
        }



        #endregion
    }
}

using NUnit.Framework;
using Calculator365;
using System;

namespace Calculator365.UnitTest
{
    [TestFixture]
    public class Calculator365Tests
    {
        private ICalculator _calculator = null!;

        [SetUp]
        public void Setup()
        {
            _calculator = new BasicCalculator();
        }

        [Test]
        public void TestAddition()
        {
            // Arrange
            string input = "1,2";
            double expected = 3;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TestInvalidInput()
        {
            string input = "5, tytyt";
            double expected = 5;
            Assert.AreEqual(expected, _calculator.Add(input));
        }

        [Test]
        public void TestMoreThanTwoNumbers()
        {
            // Arrange
            string input = "1,2,3";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Add(input));
        }

        [Test]
        public void TestEmptyInput()
        {
            // Arrange
            string input = string.Empty;
            double expected = 0;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestNullInput()
        {
            // Arrange
            string? input = null!;
            double expected = 0;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
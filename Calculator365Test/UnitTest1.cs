

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
            string input = "1,2,3,4,5,6,7,8,9,10,11,12";
            double expected = 78;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.That(expected, Is.EqualTo(result));
        }
        [Test]
        public void TestInvalidInput()
        {
            string input = "5, tytyt";
            double expected = 5;
            Assert.That(expected, Is.EqualTo(_calculator.Add(input)));
        }

        // [Test]
        // public void TestMoreThanTwoNumbers()
        // {
        //     // Arrange
        //     string input = "1,2,3";

        //     // Act & Assert
        //     Assert.DoesNotThrow<ArgumentException>(() => _calculator.Add(input));
        // }

        [Test]
        public void TestEmptyInput()
        {
            // Arrange
            string input = string.Empty;
            double expected = 0;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.That(expected, Is.EqualTo(result));
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
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void TestNewLineDelimiter()
        {
            // Arrange
            string input = "1\n2,3";
            double expected = 6;

            // Act
            double result = _calculator.Add(input);

            // Assert
            Assert.That(expected, Is.EqualTo(result));
        }
        [Test]
        public void TestNegativeNumbers()
        {
            // Arrange
            string input = "1,-2,3,-4";


            // Assert
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add(input));
            StringAssert.Contains("Negatives not allowed: -2, -4", ex.Message);
        }

    }
}
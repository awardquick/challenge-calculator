namespace Calculator365
{
    public class BasicCalculator : ICalculator
    {
        public double Add(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] numbers = input.Split(',');

            if (numbers.Length > 2)
                throw new ArgumentException("More than 2 numbers provided");

            double num1 = 0;
            double num2 = 0;

            if (numbers.Length >= 1 && double.TryParse(numbers[0], out double parsedNum1))
                num1 = parsedNum1;

            if (numbers.Length == 2 && double.TryParse(numbers[1], out double parsedNum2))
                num2 = parsedNum2;

            return num1 + num2;
        }
    }
}
using System.Text;

namespace Calculator365
{
    public class BasicCalculator : ICalculator
    {
        public double Add(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            var delimiters = GetDelimiters(ref input);
            var numbers = GetNumbers(input, delimiters);
            var formula = BuildFormula(input, numbers);

            ValidateNumbers(numbers);
            var result = numbers.Sum();
            Console.WriteLine($"{formula} = {result}");
            return result;
        }

        private IEnumerable<double> GetNumbers(string input, string[] delimiters)
        {
            return input.Split(delimiters, StringSplitOptions.None)
                .Select(n => double.TryParse(n, out var num) ? (num <= 1000 ? num : 0) : 0);
        }

        private (double result, string formula) CalculateResultAndFormula(IEnumerable<double> numbers)
        {
            StringBuilder formulaBuilder = new StringBuilder();
            double sum = 0;

            foreach (double number in numbers)
            {
                formulaBuilder.Append(number).Append("+");
                sum += number;
            }

            string formula = formulaBuilder.ToString().TrimEnd('+') + $" = {sum}";

            return (sum, formula);
        }

        private static void ValidateNumbers(IEnumerable<double> numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }


        private static string[] GetDelimiters(ref string input)
        {
            string[] delimiters = [",", "\n"]; // Default delimiters

            if (input.StartsWith("//"))
            {
                int delimiterEndIndex = input.IndexOf('\n');
                if (delimiterEndIndex == -1)
                {
                    throw new ArgumentException("Invalid custom delimiter format");
                }
                string delimiterSegment = input[2..delimiterEndIndex];

                if (delimiterSegment.StartsWith('[') && delimiterSegment.EndsWith(']'))
                {
                    // Custom delimiter enclosed within square brackets
                    string[] customDelimiters = delimiterSegment[1..^1].Split("][");
                    delimiters = [.. customDelimiters, "\n"];
                }
                else
                {
                    // Custom delimiter without square brackets
                    delimiters = [delimiterSegment, "\n"];
                }

                input = input[(delimiterEndIndex + 1)..];
            }

            return delimiters;
        }

        private static string BuildFormula(string input, IEnumerable<double> numbers)
        {
            var formulaParts = new List<string>();

            int index = 0;
            foreach (var number in numbers)
            {
                if (index < input.Length && !char.IsDigit(input[index]))
                {
                    formulaParts.Add("0");
                }
                else
                {
                    formulaParts.Add(number.ToString());
                }
                index += number.ToString().Length + 1;
            }
            return string.Join(" + ", formulaParts);
        }

    }
}
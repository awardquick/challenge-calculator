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
            ValidateNumbers(numbers);

            return numbers.Sum();
        }

        private IEnumerable<double> GetNumbers(string input, string[] delimiters)
        {
            return input.Split(delimiters, StringSplitOptions.None)
                .Select(n => double.TryParse(n, out var num) ? (num <= 1000 ? num : 0) : 0);
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

    }
}
namespace Calculator365
{
    public class BasicCalculator : ICalculator
    {
        public double Add(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] delimiters = GetDelimiters(ref input);

            string[] numbers = input.Split(delimiters, StringSplitOptions.None);

            List<double> negativeNumbers = [];

            double sum = 0;

            foreach (string number in numbers)
            {
                if (double.TryParse(number, out double parsedNum))
                {
                    if (parsedNum < 0)
                    {
                        negativeNumbers.Add(parsedNum);
                    }
                    else if (parsedNum <= 1000)
                    {
                        sum += parsedNum;
                    }
                }
                else
                    sum += 0;
            }

            if (negativeNumbers.Count != 0)
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
            }
            return sum;
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
                    string customDelimiter = delimiterSegment[1..^1];
                    delimiters = [customDelimiter, "\n"];
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
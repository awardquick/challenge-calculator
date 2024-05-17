namespace Calculator365
{
    public class BasicCalculator : ICalculator
    {
        public double Add(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string[] delimiters = [",", "\n"];
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
    }
}
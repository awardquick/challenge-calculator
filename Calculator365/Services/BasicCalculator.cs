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

            double sum = 0;

            foreach (string number in numbers)
            {
                if (double.TryParse(number, out double parsedNum))
                    sum += parsedNum;
                else
                    sum += 0;
            }
            return sum;
        }
    }
}
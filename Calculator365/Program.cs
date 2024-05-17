namespace Calculator365;

class Program
{
    static void Main(string[] args)
    {
        ICalculator calculator = new BasicCalculator();

        Console.WriteLine("Welcome to Calculator365!");
        Console.WriteLine("Enter two numbers separated by a comma to add them together.");

        string? input = Console.ReadLine();
        double result;

        try
        {
            if (input != null)
            {
                result = calculator.Add(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine($"Result: {result}");
    }
}

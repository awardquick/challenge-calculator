namespace Calculator365
{
    public interface ICalculator
    {
        (double result, string formula) Add(string? input);
    }
}
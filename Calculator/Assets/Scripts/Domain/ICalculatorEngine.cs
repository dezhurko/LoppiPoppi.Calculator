namespace LoppiPoppi.Calculator.Domain
{
    public interface ICalculatorEngine
    {
        public bool IsValid(string input);
        decimal Process(string input);
    }
}
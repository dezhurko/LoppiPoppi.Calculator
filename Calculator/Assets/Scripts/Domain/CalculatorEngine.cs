using System;
using System.Linq;

namespace LoppiPoppi.Calculator.Domain
{
    public class CalculatorEngine : ICalculatorEngine
    {
        private readonly SumInputParser parser = new SumInputParser();

        public bool IsValid(string input) => parser.IsValid(input);

        public decimal Process(string input)
        {
            if (parser.TryParse(input, out var values))
            {
                return values.Sum();
            }

            throw new InvalidOperationException();
        }
    }
}

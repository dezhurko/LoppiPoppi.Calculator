using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LoppiPoppi.Calculator.Domain
{
    internal class SumInputParser
    {
        public bool IsValid(string input)
        {
            var regex = new Regex(@"^\d+(\+\d+)+$");

            return regex.IsMatch(input);
        }

        public bool TryParse(string input, out IEnumerable<int> values)
        {
            if (!IsValid(input))
            {
                values = Array.Empty<int>();
                return false;
            }

            var valueStrings = input.Split('+');
            var result = new List<int>();
            foreach (var valuesStr in valueStrings)
            {
                if (int.TryParse(valuesStr, out var value))
                {
                    result.Add(value);
                }
            }

            values = result;
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            char? customSeparator = null;

            if (str.StartsWith("//") && str[3] == '\n')
            {
                customSeparator = str[2];
            }

            var values = customSeparator != null ? str[4..].Split('\n', customSeparator.Value) : str.Split(',', '\n');
            int sum = 0;
            foreach (var v in values)
            {
                if (int.TryParse(v, out var result))
                {
                    if (result < 0)
                        throw new ArgumentException();
                    if (result <= 1000)
                        sum += result;
                }
            }

            return sum;
        }
    }
}

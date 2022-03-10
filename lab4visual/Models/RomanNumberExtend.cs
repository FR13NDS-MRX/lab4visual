using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RomanNumberExtend : RomanNumber
{
    private Dictionary<char, ushort> romanSymbols = new Dictionary<char, ushort>()
    {
        {'M', 1000},
        {'D', 500},
        {'C', 100},
        {'L', 50},
        {'X', 10},
        {'V', 5},
        {'I', 1}
    };
    public RomanNumberExtend(string num) : base(1)
    {
        ushort resultNumber = 0;

        for (int i = 0; i < num.Length; i++)
        {
            ushort firstValue = 0, secondValue = 0;

            firstValue = romanSymbols[num[i]];
            if (i != num.Length - 1)
            {
                secondValue = romanSymbols[num[i + 1]];
            }

            int ratio = secondValue / firstValue;
            if (ratio < 5 || ratio > 10)
            {
                resultNumber += firstValue;
                continue;
            }

            resultNumber += (ushort)(secondValue - firstValue);

            i++;
        }
        decimalNumber = resultNumber;
    }
}
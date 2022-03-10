using System;
using System.Collections.Generic;
using System.Text;

public class RomanNumber : ICloneable, IComparable
{
    private protected string romanNumber = "";
    private protected ushort decimalNumber;
    public RomanNumber(ushort n)
    {
        if (n <= 0 || n >= 4000)
        {
            throw new RomanNumberException("Некорректное десятичное число");
        }
        decimalNumber = n;
    }
    public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber + n2.decimalNumber > 3999)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }
        return new RomanNumber((ushort)(n1.decimalNumber + n2.decimalNumber));
    }
    public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber - n2.decimalNumber <= 0)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }

        return new RomanNumber((ushort)(n1.decimalNumber - n2.decimalNumber));
    }
    public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber * n2.decimalNumber > 3999)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }
        return new RomanNumber((ushort)(n1.decimalNumber * n2.decimalNumber));
    }
    public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null || n1.decimalNumber / n2.decimalNumber <= 0)
        {
            throw new RomanNumberException("Некорректные входные данные");
        }

        return new RomanNumber((ushort)(n1.decimalNumber / n2.decimalNumber));
    }
    public override string ToString()
    {
        if (romanNumber == "")
        {
            ushort n = decimalNumber;
            string[] romanSymbols = new string[] { "M", "D", "C", "L", "X", "V", "I" };

            ushort romanSymbolValue = 1000;

            for (int i = 0; i < romanSymbols.Length; i += 2)
            {
                int digit = n / romanSymbolValue;

                if (digit == 9)
                {
                    romanNumber += romanSymbols[i] + romanSymbols[i - 2];
                    digit = 0;
                }
                if (digit >= 5)
                {
                    romanNumber += romanSymbols[i - 1];
                    digit -= 5;
                }
                if (digit == 4)
                {
                    romanNumber += romanSymbols[i] + romanSymbols[i - 1];
                    digit = 0;
                }
                for (int j = 0; j < digit; j++)
                {
                    romanNumber += romanSymbols[i];
                }

                n %= romanSymbolValue;

                romanSymbolValue /= 10;
            }
        }
        return romanNumber;
    }

    public object Clone()
    {
        return new RomanNumber(decimalNumber);
    }

    public int CompareTo(object? o)
    {
        if (o is RomanNumber number)
        {
            return number.decimalNumber - decimalNumber;
        }
        throw new RomanNumberException("Некорректное значение параметра");
    }
}
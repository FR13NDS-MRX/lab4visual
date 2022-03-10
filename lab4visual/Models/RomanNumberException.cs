using System;
using System.Collections.Generic;
using System.Text;

public class RomanNumberException : Exception
{
    public RomanNumberException(string message) : base(message) { }
}
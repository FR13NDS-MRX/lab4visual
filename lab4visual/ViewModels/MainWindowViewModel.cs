using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace lab4visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string calcText = "";
        RomanNumberExtend firstNumber;
        string operatorSymbol = "";
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => CalcText = str);
        }
        public string CalcText
        {
            set
            {
                if (calcText == "asd")
                {
                    calcText = "";
                    operatorSymbol = "";
                }
                try
                {
                    if (value == "+" || value == "-" || value == "*" || value == "/")
                    {
                        if (operatorSymbol != "")
                        {
                            throw new RomanNumberException("");
                        }
                        if (calcText == "")
                        {
                            throw new RomanNumberException("");
                        }
                        firstNumber = new RomanNumberExtend(calcText);
                        operatorSymbol = value;
                        this.RaiseAndSetIfChanged(ref calcText, value);
                        return;
                    }
                    if (value == "=")
                    {
                        if (operatorSymbol == "")
                        {
                            throw new RomanNumberException("");
                        }
                        if (calcText == "")
                        {
                            throw new RomanNumberException("");
                        }
                        RomanNumberExtend a = new RomanNumberExtend(calcText);
                        if (operatorSymbol == "+")
                        {
                            RomanNumber result = firstNumber + a;
                            this.RaiseAndSetIfChanged(ref calcText, result.ToString());
                        }
                        if (operatorSymbol == "-")
                        {
                            RomanNumber result = firstNumber - a;
                            this.RaiseAndSetIfChanged(ref calcText, result.ToString());
                        }
                        if (operatorSymbol == "*")
                        {
                            RomanNumber result = firstNumber * a;
                            this.RaiseAndSetIfChanged(ref calcText, result.ToString());
                        }
                        if (operatorSymbol == "/")
                        {
                            RomanNumber result = firstNumber / a;
                            this.RaiseAndSetIfChanged(ref calcText, result.ToString());
                        }
                        operatorSymbol = "";
                        return;
                    }
                    if (calcText == "+" || calcText == "-" || calcText == "*" || calcText == "/")
                    {
                        this.RaiseAndSetIfChanged(ref calcText, value);
                        return;
                    }
                    this.RaiseAndSetIfChanged(ref calcText, calcText + value);
                }
                catch
                {
                    this.RaiseAndSetIfChanged(ref calcText, "");
                }
            }
            get
            {
                return calcText;
            }
        }
        public ReactiveCommand<string, string> OnClickCommand { get; set; }
    }
}
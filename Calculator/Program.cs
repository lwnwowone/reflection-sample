using System;
using Calculator.DLLLoader;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DllManager.GetInstance().LoadDlls();
            new CalculatorCLI().Start();
        }
    }
}

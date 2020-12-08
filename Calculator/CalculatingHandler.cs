using System;
using ICalculating;

namespace Calculator
{
    public class CalculatingHandler
    {
        public ICalculatingOperation calculatingOperation { get; set; }
        double num1;
        double num2;

        public CalculatingHandler(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public double Calculate() {
            return calculatingOperation.Calculate(num1, num2);
        }
    }
}

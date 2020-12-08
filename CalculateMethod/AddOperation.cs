using System;
using ICalculating;

namespace CalculateMethod
{
    public class AddOperation: ICalculatingOperation
    {

        public double Calculate(double num1, double num2)
        {
            return num1 + num2;
        }

    }
}

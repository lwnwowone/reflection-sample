using System;
using ICalculating;

namespace ExtraCalculateMethod
{
    public class MulMethod: ICalculatingOperation
    {

        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }

    }
}

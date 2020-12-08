using System;
using ICalculating;

namespace Calculator
{
    public class CalculatorCLI
    {
        CalculatingOperationReslover reslover = new CalculatingOperationReslover();

        double result = 0;

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Current result = {0}", result);

                Console.Write("Please input a operator:", result);
                string operatorStr = Console.ReadLine();
                ICalculatingOperation calculatingOperation = reslover.resolve(operatorStr);
                if (null == calculatingOperation)
                {
                    Console.WriteLine("The operator {0}, is not supported, please try again!", operatorStr);
                    continue;
                }

                Console.Write("Please input a number:");
                string numberStr = Console.ReadLine();
                double num;
                try
                {
                    num = double.Parse(numberStr);
                }
                catch
                {
                    Console.WriteLine("The number {0}, is invalid, please try again!", numberStr);
                    continue;
                }

                CalculatingHandler handler = new CalculatingHandler(result, num);
                handler.calculatingOperation = calculatingOperation;
                result = handler.Calculate();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using Calculator.DLLLoader;
using ICalculating;
using Newtonsoft.Json;

namespace Calculator
{
    public class CalculatingOperationReslover
    {
        public ICalculatingOperation resolve(string operatorStr)
        {
            string configPath = Environment.CurrentDirectory + "/Config.txt";
            string configContent = System.IO.File.ReadAllText(configPath);
            //Console.WriteLine("config content: \n{0}\n", configContent);

            Dictionary<string, string> configDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(configContent);
            if (configDic.ContainsKey(operatorStr))
            {
                string className = configDic[operatorStr];
                //Console.WriteLine("Operation found, className = {0}", className);

                ICalculatingOperation operation = DllManager.GetInstance().createInstanceFromLoadedDLL(className);
                return operation;
            }
            else
            {
                Console.WriteLine("Operation {0} isn't defined in config!", operatorStr);
            }
            
            return null;
        }

    }
}

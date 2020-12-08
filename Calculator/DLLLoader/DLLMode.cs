using System;
using System.Reflection;

namespace Calculator.DLLLoader
{
    public class DLLModel
    {
        public string DllName { get; set; }
        public Assembly Assembly { get; set; }

        public DLLModel(string dllName, Assembly assembly)
        {
            this.DllName = dllName;
            this.Assembly = assembly;
        }
    }
}

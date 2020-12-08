using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ICalculating;

namespace Calculator.DLLLoader
{
    public class DllManager
    {
        private static DllManager uniqueInstance;

        public static DllManager GetInstance()
        {
            // 如果类的实例不存在则创建，否则直接返回
            if (uniqueInstance == null)
            {
                uniqueInstance = new DllManager();
            }
            return uniqueInstance;
        }

        // 定义私有构造函数，使外界不能创建该类实例
        private DllManager()
        {
        }

        private List<DLLModel> assemblyList = new List<DLLModel>();

        public void LoadDlls()
        {
            string searchPath = Environment.CurrentDirectory;
            Console.WriteLine("exe path: {0}", searchPath);

            var files = Directory.GetFiles(searchPath, "*.dll");

            foreach (var file in files)
            {
                if (file.Contains("CalculateMethod"))
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    assemblyList.Add(new DLLModel(fileName, assembly));
                }
            }

            Console.WriteLine("loaded dlls count = {0}", assemblyList.Count);
        }

        public ICalculatingOperation createInstanceFromLoadedDLL(string className)
        {
            foreach (DLLModel model in assemblyList)
            {
                //获取类型 （获取类型信息的方式不止一个）
                string typeName = model.DllName + "." + className;
                Type targetType = model.Assembly.GetType();
                if (null != targetType)
                {
                    //创建对象 
                    object tmp = model.Assembly.CreateInstance(typeName);
                    ICalculatingOperation result = tmp as ICalculatingOperation;
                    if (null != result) {
                        return result;
                    }
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLoaderBase;
using System.IO;
using System.Reflection;

namespace TransactionLoader
{
    class ConverterFactory
    {
        private static ConverterFactory instance = new ConverterFactory();
        private ConverterFactory() { }
        public static ConverterFactory Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Get IConverter by filepath
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IConverter GetConverter(string filePath)
        {
            try
            {
                string extName = Path.GetExtension(filePath).ToLower().Replace(".", "");
                string converterName = GetConverterNameFromConfig(extName);
                object[] converterParams = new object[] { filePath };

                Type converterType = FindClass(converterName);
                return Activator.CreateInstance(converterType, converterParams) as IConverter;
            }
            catch (ArgumentException)
            {
                throw new CustomException("Invalid config file path.");
            }
            catch (CustomException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new Exception("Unexpected error when creating converter instance.");
            }            
        }

        private Type FindClass(string converterName)
        {
            string[] assemblies = Directory.GetFiles(System.Environment.CurrentDirectory, "*.dll");
            foreach (string assemblyPath in assemblies)
            {
                Type[] types = null;
                try
                {
                    types = Assembly.LoadFrom(assemblyPath).GetTypes();
                    var converterType = types.Where(t =>
                        t.IsClass &&
                        t.GetInterfaces().Contains(typeof(TransactionLoaderBase.IConverter)) &&
                        t.Name.Equals(converterName)
                    ).ToList();
                    
                    if (converterType.ToList().Count > 1)
                    {
                        throw new CustomException("Wrong design of converter component!");
                    }
                    else if (converterType.ToList().Count == 1)
                    {
                        return converterType[0] as Type;
                    }
                }
                catch (ArgumentNullException)
                {
                    continue; // 這個dll不能load或找不到半個適合的class就換下一個dll啊~
                }
            }
            throw new CustomException("Unsupported converter.");
        }

        /// <summary>
        /// Get converter name from config by input billing file's extension name
        /// </summary>
        /// <param name="extName"></param>
        /// <returns></returns>
        private string GetConverterNameFromConfig(string extName)
        {
            try
            {
                List<Dictionary<string, string>> configs = ConfigManager.GetConfigs();
                foreach (Dictionary<string, string> config in configs)
                {
                    if (extName == config["ExtName"])
                    {
                        return config["Converter"];
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                throw new CustomException("Field name not matched between config file and code.");
            }
            throw new CustomException("Unsupported format.");
        }
    }
}

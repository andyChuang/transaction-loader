using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
            string extName = ParseExtName(filePath).ToLower();
            string converterName = GetConverterNameFromConfig(extName);
            string nameSpaceName = "TransactionLoader";
            object[] converterParams = new object[] { filePath };
            IConverter converterObj = Activator.CreateInstance(Type.GetType(nameSpaceName + "." + converterName), converterParams) as IConverter;
            return converterObj;
        }

        /// <summary>
        /// Parse extension name of file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string ParseExtName(string filePath)
        {
            var tmp = filePath.LastIndexOf('.');
            return filePath.Substring(tmp + 1, filePath.Length - tmp - 1);
        }

        private string GetConverterNameFromConfig(string extName)
        {
            JArray configs = ConfigManager.GetConfigs();
            foreach (JObject config in configs)
            {
                if (extName == (string)config.GetValue("ExtName"))
                {
                    return (string)config.GetValue("Converter");
                }
            }
            throw new Exception("Unsupported format.");
        }
    }
}

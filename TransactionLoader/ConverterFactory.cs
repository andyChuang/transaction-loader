using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string nameSpaceName = "TransactionLoader";
            string converterName = GetConverterNameFromConfig(extName);
            object[] converterParams = new object[] { filePath };

            try
            {
                return  Activator.CreateInstance(Type.GetType(nameSpaceName + "." + converterName), converterParams) as IConverter;
            }
            catch
            { 
                throw new Exception("Invalid converter name.");
            }            
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
                throw new KeyNotFoundException("Field name not matched between config file and code.");
            }
            throw new Exception("Unsupported format.");
        }
    }
}

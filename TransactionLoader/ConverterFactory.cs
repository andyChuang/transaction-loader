using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string extName = ParseExtName(filePath).ToLower();

            var type = typeof(IConverter);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            object converterInstance;
            bool isExtNameMatched = false;

            foreach (Type converterType in types)
            {
                converterInstance = Activator.CreateInstance(converterType, new object[] { filePath });
                isExtNameMatched = (bool)converterType.InvokeMember("IsExtNameMatched", BindingFlags.InvokeMethod,
                                        null, converterInstance, new object[] { extName });
                if(isExtNameMatched)
                {
                    return converterInstance as IConverter;
                }
            }

            throw new ArgumentException("Unsupported format.");
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
    }
}

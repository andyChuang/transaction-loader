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
            set
            { 
            }
        }

        /// <summary>
        /// Get IConverter by filepath
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IConverter GetConverter(string filePath)
        {
            string extName = ParseExtName(filePath).ToUpper();

            if (extName==BillingFileExtName.CHAR.ToString())
            {
                return new CyberMarsConverter(filePath);
            }
            else if (extName == BillingFileExtName.CSV.ToString())
            {
                return new CsvConverter(filePath);
            }
            else
            {
                throw new ArgumentException("Unsupported format.");
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
    }
}

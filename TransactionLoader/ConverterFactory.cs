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

        public IConverter GetConverter(string filePath)
        { 
            switch (ParseExtName(filePath))
            {
                case "char":
                    return new CyberMarsConverter(filePath);
                case "csv":
                    return new CsvConverter(filePath);
                default:
                    throw new ArgumentException("Unsupported format.");
            }
        }

        private string ParseExtName(string filePath)
        {
            var tmp = filePath.LastIndexOf('.');
            return filePath.Substring(tmp + 1, filePath.Length - tmp - 1);
        }
    }
}

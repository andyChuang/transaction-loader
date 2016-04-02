using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class TransactionLoader
    {
        private string filePath { get; set; }
        public TransactionLoader(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Transaction> Convert()
        {
            try
            {
                List<Transaction> result = ConverterFactory.Instance.GetConverter(filePath).Convert();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return null;
            }
        }
    }
}

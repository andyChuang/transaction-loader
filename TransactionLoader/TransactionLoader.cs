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
                return ConverterFactory.Instance.GetConverter(filePath).Convert();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

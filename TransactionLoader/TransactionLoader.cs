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
        public TransactionLoader(string filePath, string configPath)
        {
            this.filePath = filePath;
            ConfigManager.ConfigPath = configPath;
        }

        /// <summary>
        /// Convert billing file data to transactions
        /// </summary>
        /// <returns></returns>
        public List<Transaction> Convert()
        {
            try
            {
                List<Transaction> result = ConverterFactory.Instance.GetConverter(filePath).Convert();
                
                foreach (Transaction transaction in result)
                {
                    Console.WriteLine("SEQ: " + transaction.SEQ);
                    Console.WriteLine("TransType: " + transaction.TransactionType);
                    Console.WriteLine("MerchantId: " + transaction.MerchantId);
                    Console.WriteLine("CardNo: " + transaction.CardNo);
                    Console.WriteLine("ExpireDate: " + transaction.ExpireDate);
                    Console.WriteLine("TransAmt: " + transaction.TransactionAmount);
                    Console.WriteLine("TransDate: " + transaction.TransactionDate);
                    Console.WriteLine("TransTime: " + transaction.TransactionTime);
                    Console.WriteLine("CardType: " + transaction.CardType);
                    Console.WriteLine("==================================");
                }
                Console.ReadKey();
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

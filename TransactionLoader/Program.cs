using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLoaderBase;

namespace TransactionLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = LoadTransactionsFromChargeFile("charge.json", "transactionLoader.config");
            ShowResult(transaction);
        }

        static public List<Transaction> LoadTransactionsFromChargeFile(string filePath, string configPath)
        {
            TransactionLoader transLoader = new TransactionLoader(filePath, configPath);
            return transLoader.Convert();
        }

        static private void ShowResult(List<Transaction> transactions)
        {
            if (transactions == null)
            {
                return;
            }
            foreach (Transaction transaction in transactions)
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
        }
    }
}

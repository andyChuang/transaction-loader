using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = LoadTransactionsFromChargeFile("charge.csv");

            foreach (Transaction trans in transaction)
            {
                Console.WriteLine("SEQ: " + trans.SEQ);
                Console.WriteLine("TransType: " + trans.TransactionType);
                Console.WriteLine("MerchantId: " + trans.MerchantId);
                Console.WriteLine("CardNo: " + trans.CardNo);
                Console.WriteLine("ExpireDate: " + trans.ExpireDate);
                Console.WriteLine("TransAmt: " + trans.TransactionAmount);
                Console.WriteLine("TransDate: " + trans.TransactionDate);
                Console.WriteLine("TransTime: " + trans.TransactionTime);
                Console.WriteLine("CardType: " + trans.CardType);
                Console.WriteLine("==================================");
            }
            Console.ReadKey();
        }

        static public List<Transaction> LoadTransactionsFromChargeFile(string FilePath)
        {
            TransactionLoader transLoader = new TransactionLoader(FilePath);
            return transLoader.Convert();
        }   
    }
}

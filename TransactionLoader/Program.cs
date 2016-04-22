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
            var transcation = LoadTransactionsFromChargeFile("charge.csv", "transactionLoader.config");
        }

        static public List<Transaction> LoadTransactionsFromChargeFile(string filePath, string configPath)
        {
            TransactionLoader transLoader = new TransactionLoader(filePath, configPath);
            return transLoader.Convert();
        }   
    }
}

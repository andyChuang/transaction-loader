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
            var transcation = LoadTransactionsFromChargeFile("charge.json");
        }

        static public List<Transaction> LoadTransactionsFromChargeFile(string FilePath)
        {
            TransactionLoader transLoader = new TransactionLoader(FilePath);
            return transLoader.Convert();
        }   
    }
}

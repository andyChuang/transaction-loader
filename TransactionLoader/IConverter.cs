using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    interface IConverter
    {
        string filePath { get; set; }
        List<Transaction> Convert();
        void Validate(string data);
        List<string> Parse(string data);
        Transaction GetTransaction(List<string> dataList);
    }
}

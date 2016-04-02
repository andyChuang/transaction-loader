using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class CsvConverter : IConverter
    {
        public string filePath { get; set; }
        public CsvConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Transaction> Convert()
        {
            string[] data = FileReadService.Instance.ReadTextFile(this.filePath);
            return null;
        }

        public void Validate()
        {
            return;
        }
    }
}

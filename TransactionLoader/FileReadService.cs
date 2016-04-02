using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TransactionLoader
{
    class FileReadService
    {
        private static FileReadService instance = new FileReadService();
        private FileReadService() { }
        public static FileReadService Instance
        {
            get
            {
                return instance;
            }
            set 
            { 
            }
        }

        public string[] ReadTextFile(string filePath)
        {
            return System.IO.File.ReadAllLines(@filePath);
        }

        public Byte[] ReadBytesFile(string filePath)
        {
            return null;
        }
    }
}

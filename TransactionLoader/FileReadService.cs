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
        }

        public string[] ReadTextFile(string filePath)
        {
            try
            {
                string[] result = System.IO.File.ReadAllLines(@filePath);
                return result;
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("Billing file not found.");
            }
        }

        public string ReadTextFileInOneString(string filePath)
        {
            try
            {
                string result = System.IO.File.ReadAllText(@filePath);
                return result;
            }
            catch (FileNotFoundException e)
            {
                throw new Exception("Billing file not found.");
            }
        }

        public Byte[] ReadBytesFile(string filePath)
        {
            // TODO: Implement it
            return null;
        }
    }
}

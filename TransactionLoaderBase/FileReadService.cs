using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TransactionLoaderBase
{
    public class FileReadService
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

        /// <summary>
        /// Read text file and return a string array
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string[] ReadTextFileIntoStringArray(string filePath)
        {
            try
            {
                string[] result = System.IO.File.ReadAllLines(@filePath);
                return result;
            }
            catch (FileNotFoundException e)
            {
                throw new CustomException("Billing file not found.");
            }
        }

        /// <summary>
        /// Read text file and merged all content into a string
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string ReadTextFileIntoOneString(string filePath)
        {
            try
            {
                string result = System.IO.File.ReadAllText(@filePath);
                if (result.Length == 0)
                {
                    throw new CustomException("Empty file.");
                }
                return result;
            }
            catch (FileNotFoundException e)
            {
                throw new CustomException("Config file not found.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLoaderBase;

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
                return ConverterFactory.Instance.GetConverter(filePath).Convert();
            }
            catch (CustomException e)
            {
                e.WhatHappenedBaby();
                Console.ReadKey();
                return null;
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

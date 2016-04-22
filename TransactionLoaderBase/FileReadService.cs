﻿using System;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoaderBase
{
    public class CustomException : Exception
    {
        public string ErrorMsg { get; set; }
        public CustomException(string errorMsg)
        {
            this.ErrorMsg = errorMsg;
        }

        public void WhatHappenedBaby()
        {
            Console.WriteLine(this.ErrorMsg);
        }
    }
}

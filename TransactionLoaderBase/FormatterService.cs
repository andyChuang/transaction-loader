using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoaderBase
{
    public class FormatterService
    {
        private static FormatterService instance = new FormatterService();
        private FormatterService() { }
        public static FormatterService Instance
        {
            get
            {
                return instance;
            }
        }

        public decimal StringToDecimal(string amount, int decimalPlaces)
        {
            amount = TrimPrefixZeroPadding(amount);
            string integerPart = amount.Substring(0, amount.Length - decimalPlaces);
            string decimalPart = amount.Substring(amount.Length - decimalPlaces, decimalPlaces);
            string newDecimal = integerPart + "." + decimalPart;
            return Decimal.Parse(newDecimal);
        }

        public DateTime StringToDate(string dateTime)
        {
            string year = dateTime.Substring(0, 4);
            string month = dateTime.Substring(4, 2);
            string day = dateTime.Substring(6, 2);
            string newDateTime = year + "/" + month + "/" + day;
            return Convert.ToDateTime(newDateTime);
        }

        public DateTime StringToTime(string dateTime)
        {
            string hour = dateTime.Substring(0, 2);
            string minute = dateTime.Substring(2, 2);
            string second = dateTime.Substring(4, 2);
            string newDateTime = hour + ":" + minute + ":" + second;
            return Convert.ToDateTime(newDateTime);
        }

        private string TrimPrefixZeroPadding(string data)
        {
            return data.TrimStart(new char[] { '0' });
        }
    }
}

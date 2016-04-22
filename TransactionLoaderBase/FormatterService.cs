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

        /// <summary>
        /// Convert string format to decimal format
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public decimal StringToDecimal(string amount, int decimalPlaces)
        {
            amount = TrimPrefixZeroPadding(amount);
            string integerPart = amount.Substring(0, amount.Length - decimalPlaces);
            string decimalPart = amount.Substring(amount.Length - decimalPlaces, decimalPlaces);
            string newDecimal = integerPart + "." + decimalPart;
            return Decimal.Parse(newDecimal);
        }

        /// <summary>
        /// Convert string to date format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime StringToDate(string dateTime)
        {
            string year = dateTime.Substring(0, 4);
            string month = dateTime.Substring(4, 2);
            string day = dateTime.Substring(6, 2);
            string newDateTime = year + "/" + month + "/" + day;
            return Convert.ToDateTime(newDateTime);
        }

        /// <summary>
        /// Convert string to time format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime StringToTime(string dateTime)
        {
            string hour = dateTime.Substring(0, 2);
            string minute = dateTime.Substring(2, 2);
            string second = dateTime.Substring(4, 2);
            string newDateTime = hour + ":" + minute + ":" + second;
            return Convert.ToDateTime(newDateTime);
        }

        /// <summary>
        /// Trim all zero appear in front
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string TrimPrefixZeroPadding(string data)
        {
            return data.TrimStart(new char[] { '0' });
        }
    }
}

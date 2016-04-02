using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class FormatterService
    {
        public static decimal StringToDecimal(string amount, int decimalPlaces)
        {
            amount = TrimZeroPadding(amount);
            string integerPart = amount.Substring(0, amount.Length - decimalPlaces);
            string decimalPart = amount.Substring(amount.Length - decimalPlaces, decimalPlaces);
            string newDecimal = integerPart + "." + decimalPart;
            return Decimal.Parse(newDecimal);
        }

        public static DateTime StringToDate(string dateTime)
        {
            string year = dateTime.Substring(0, 4);
            string month = dateTime.Substring(4, 2);
            string day = dateTime.Substring(6, 2);
            string newDateTime = year + "/" + month + "/" + day;
            return Convert.ToDateTime(newDateTime);
        }

        public static DateTime StringToTime(string dateTime)
        {
            string hour = dateTime.Substring(0, 2);
            string minute = dateTime.Substring(2, 2);
            string second = dateTime.Substring(4, 2);
            string newDateTime = hour + ":" + minute + ":" + second;
            return Convert.ToDateTime(newDateTime);
        }

        public static string TrimZeroPadding(string data)
        {
            return data.TrimStart(new char[] { '0' });
        }
    }
}

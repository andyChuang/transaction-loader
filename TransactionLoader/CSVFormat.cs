using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    static class CsvFormat
    {
        public static readonly string TRANSTYPE_SALE = "5";
        public static readonly string TRANSTYPE_REFUND = "6";

        public static readonly string CARDTYPE_JCB = "J";
        public static readonly string CARDTYPE_VISA = "V";
        public static readonly string CARDTYPE_MASTER = "M";
        public static readonly string CARDTYPE_UNIONPAY = "U";

        public static readonly string EXTNAME = "csv";
    }
}

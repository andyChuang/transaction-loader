using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class JsonFormat
    {
        public static readonly string TRANSTYPE_SALE = "Sale";
        public static readonly string TRANSTYPE_REFUND = "Refund";

        public static readonly string CARDTYPE_JCB = "JCB";
        public static readonly string CARDTYPE_VISA = "VISA";
        public static readonly string CARDTYPE_MASTER = "MASTER";
        public static readonly string CARDTYPE_UNIONPAY = "UnionPay";

        public static readonly string EXTNAME = "json";
    }
}

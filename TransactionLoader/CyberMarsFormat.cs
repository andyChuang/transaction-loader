using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class CyberMarsFormat
    {
        public static readonly int TOTAL_LENGTH = 66;

        public static readonly string TRANSTYPE_SALE = "0";
        public static readonly string TRANSTYPE_REFUND = "1";

        public static readonly string CARDTYPE_JCB = "0";
        public static readonly string CARDTYPE_VISA = "1";
        public static readonly string CARDTYPE_MASTER = "2";
        public static readonly string CARDTYPE_UNIONPAY = "3";

        public static readonly int SEQ_LENGTH = 8;
        public static readonly int TRANSACTION_TYPE_LENGTH = 1;
        public static readonly int MERCHANT_ID_LENGTH = 10;
        public static readonly int CARD_NO_LENGTH = 16;
        public static readonly int EXPIRE_DATE_LENGTH = 4;
        public static readonly int TRANSACTION_AMOUNT_LENGTH = 12;
        public static readonly int TRANSACTION_DATE_LENGTH = 8;
        public static readonly int TRANSACTION_TIME_LENGTH = 6;
        public static readonly int CARD_TYPE_LENGTH = 1;

        public static readonly int SEQ_START = 0;
        public static readonly int TRANSACTION_TYPE_START = 8;
        public static readonly int MERCHANT_ID_START = 9;
        public static readonly int CARD_NO_START = 19;
        public static readonly int EXPIRE_DATE_START = 35;
        public static readonly int TRANSACTION_AMOUNT_START = 39;
        public static readonly int TRANSACTION_DATE_START = 51;
        public static readonly int TRANSACTION_TIME_START = 59;
        public static readonly int CARD_TYPE_START = 65;
    }
}

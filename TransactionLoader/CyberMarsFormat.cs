using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class CyberMarsFormat
    {
        static public int TOTAL_LENGTH = 66;

        static public string TRANSTYPE_SALE = "0";
        static public string TRANSTYPE_REFUND = "1";

        static public string CARDTYPE_JCB = "0";
        static public string CARDTYPE_VISA = "1";
        static public string CARDTYPE_MASTER = "2";

        static public int SEQ_LENGTH = 8;
        static public int TRANSACTION_TYPE_LENGTH = 1;
        static public int MERCHANT_ID_LENGTH = 10;
        static public int CARD_NO_LENGTH = 16;
        static public int EXPIRE_DATE_LENGTH = 4;
        static public int TRANSACTION_AMOUNT_LENGTH = 12;
        static public int TRANSACTION_DATE_LENGTH = 8;
        static public int TRANSACTION_TIME_LENGTH = 6;
        static public int CARD_TYPE_LENGTH = 1;

        static public int SEQ_START = 0;
        static public int TRANSACTION_TYPE_START = 8;
        static public int MERCHANT_ID_START = 9;
        static public int CARD_NO_START = 19;
        static public int EXPIRE_DATE_START = 35;
        static public int TRANSACTION_AMOUNT_START = 39;
        static public int TRANSACTION_DATE_START = 51;
        static public int TRANSACTION_TIME_START = 59;
        static public int CARD_TYPE_START = 65;
    }
}

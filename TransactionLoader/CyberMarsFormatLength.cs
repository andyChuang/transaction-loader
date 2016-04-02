using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class CyberMarsFormatLength
    {
        static public int SEQ = 8;
        static public int TRANSACTION_TYPE = 1;
        static public int MERCHANT_ID = 10;
        static public int CARD_NO = 16;
        static public int EXPIRE_DATE = 4;
        static public int TRANSACTION_AMOUNT = 12;
        static public int TRANSACTION_DATE = 8;
        static public int TRANSACTION_TIME = 6;
        static public int CARD_TYPE = 1;
    }
}

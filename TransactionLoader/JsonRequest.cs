using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionLoader
{
    [Serializable]
    class JsonRequest
    {
        public JsonRequest() { }
        public string DataSeq { get; set; }
        public string TransactionType { get; set; }
        public string MerchantId { get; set; }
        public string CardNo { get; set; }
        public string ExpiredDate { get; set; }
        public string TransactionAmount { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string CardType { get; set; }
    }
}

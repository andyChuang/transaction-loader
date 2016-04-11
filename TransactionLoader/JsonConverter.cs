using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace TransactionLoader
{
    class JsonConverter : IConverter
    {
        public string filePath { get; set; }

        public JsonConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Transaction> Convert()
        {
            string[] data = FileReadService.Instance.ReadTextFile(this.filePath);      
            List<Transaction> transList = new List<Transaction>();

            if (data.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            
            JArray requests = JArray.Parse(@String.Join("", data));

            foreach (JObject request in requests)
            {
                transList.Add(this.GetTransaction(request));
            }
            return transList;
        }

        private Transaction GetTransaction(JObject request)
        {
            Transaction newTrans = new Transaction();

            try
            {
                // SEQ
                newTrans.SEQ = (string)request.GetValue(JsonFields.DATA_SEQ);
                // Transaction Type
                string transType = (string)request.GetValue(JsonFields.TRANS_TYPE);
                if (transType == JsonFormat.TRANSTYPE_SALE)
                {
                    newTrans.TransactionType = TransType.SALE;
                }
                else if (transType == JsonFormat.TRANSTYPE_REFUND)
                {
                    newTrans.TransactionType = TransType.REFUND;
                }
                else
                {
                    throw new ArgumentException("Invalid transaction type.");
                }
                // Merchant Id
                newTrans.MerchantId = (string)request.GetValue(JsonFields.MERCHANT_ID);
                // Card No
                newTrans.CardNo = (string)request.GetValue(JsonFields.CARD_NO);
                // Expired Date
                newTrans.ExpireDate = (string)request.GetValue(JsonFields.EXPIRED_DATE);
                // Transaction Amount
                try
                {
                    newTrans.TransactionAmount = Decimal.Parse((string)request.GetValue(JsonFields.TRANS_AMT));
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction amount");
                }
                // Transaction Date
                try
                {
                    newTrans.TransactionDate = System.Convert.ToDateTime(((string)request.GetValue(JsonFields.TRANS_DATE)));
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction date");
                }
                // Transaction Time
                try
                {
                    newTrans.TransactionTime = System.Convert.ToDateTime((string)request.GetValue(JsonFields.TRANS_TIME));
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction time");
                }
                // CardType
                string cardType = (string)request.GetValue(JsonFields.CARD_TYPE);
                if (cardType == JsonFormat.CARDTYPE_MASTER)
                {
                    newTrans.CardType = CardType.MASTER;
                }
                else if (cardType == JsonFormat.CARDTYPE_VISA)
                {
                    newTrans.CardType = CardType.VISA;
                }
                else if (cardType == JsonFormat.CARDTYPE_JCB)
                {
                    newTrans.CardType = CardType.JCB;
                }
                else if (cardType == JsonFormat.CARDTYPE_UNIONPAY)
                {
                    newTrans.CardType = CardType.UNIONPAY;
                }
                else
                {
                    throw new ArgumentException("Invalid card type.");
                }
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Missing fields from Json file.");
            }
            return newTrans;
        }
    }
}

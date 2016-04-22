using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransactionLoaderBase;

namespace JsonConverter
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
            string data = FileReadService.Instance.ReadTextFileIntoOneString(this.filePath);    
            List<Transaction> transList = new List<Transaction>();

            if (data.Length == 0)
            {
                throw new CustomException("Empty file.");
            }

            List<Dictionary<string, string>> requests = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(data);

            foreach (Dictionary<string, string> request in requests)
            {
                transList.Add(this.GetTransaction(request));
            }
            return transList;
        }

        private Transaction GetTransaction(Dictionary<string, string> request)
        {
            Transaction newTrans = new Transaction();
            try
            {
                // SEQ
                newTrans.SEQ = request[JsonFields.DATA_SEQ];
                // Transaction Type
                string transType = request[JsonFields.TRANS_TYPE];
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
                    throw new CustomException("Invalid transaction type.");
                }
                // Merchant Id
                newTrans.MerchantId = request[JsonFields.MERCHANT_ID];
                // Card No
                newTrans.CardNo = request[JsonFields.CARD_NO];
                // Expired Date
                newTrans.ExpireDate = request[JsonFields.EXPIRED_DATE];
                // Transaction Amount
                decimal transAmt;
                if (!Decimal.TryParse(request[JsonFields.TRANS_AMT], out transAmt))
                {
                    throw new CustomException("Invalid transaction amount");
                }
                newTrans.TransactionAmount = transAmt;
                // Transaction Date
                try
                {
                    newTrans.TransactionDate = System.Convert.ToDateTime((request[JsonFields.TRANS_DATE]));
                }
                catch (FormatException)
                {
                    throw new CustomException("Invalid transaction date");
                }
                // Transaction Time
                try
                {
                    newTrans.TransactionTime = System.Convert.ToDateTime(request[JsonFields.TRANS_TIME]);
                }
                catch (FormatException)
                {
                    throw new CustomException("Invalid transaction time");
                }
                // CardType
                string cardType = request[JsonFields.CARD_TYPE];
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
                    throw new CustomException("Invalid card type.");
                }
            }
            catch (KeyNotFoundException)
            {
                throw new CustomException("Field not matched between file and code.");
            }

            return newTrans;
        }
    }
}

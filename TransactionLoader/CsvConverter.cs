using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoader
{
    class CsvConverter : IConverter
    {
        public string filePath { get; set; }
        public string[] headerRow;

        public CsvConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Transaction> Convert()
        {
            List<string> data = FileReadService.Instance.ReadTextFile(this.filePath).ToList();
            List<Transaction> transList = new List<Transaction>();

            if (data.Count == 0)
            {
                throw new Exception("Empty file.");
            }
            // Get header for fields
            headerRow = data[0].Split(new char[] { ',' });
            data.RemoveAt(0);

            foreach (string dataUnit in data)
            { 
                this.Validate(dataUnit);
                Dictionary<string, string> dataDict = Parse(dataUnit);
                transList.Add(this.GetTransaction(dataDict));
            }
            return transList;
        }

        private void Validate(string data)
        {
            string[] fields = data.Split(new char[] { ',' });
            if (fields.Length != headerRow.Length)
            {
                throw new IndexOutOfRangeException("Field count of header and data are not matched.");
            }
            return;
        }

        private Dictionary<string, string> Parse(string data)
        {
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            string[] fields = data.Split(new char[]{','});

            for (var i = 0; i < fields.Length; i++)
            {
                dataDict.Add(headerRow[i], fields[i]);
            }
            return dataDict;
        }

        private Transaction GetTransaction(Dictionary<string, string> dataDict)
        {
            Transaction newTrans = new Transaction();

            try
            {
                // SEQ
                newTrans.SEQ = dataDict[CSVFields.DATA_SEQ.ToString()];
                // Transaction Type
                if (dataDict[CSVFields.TRANS_TYPE.ToString()] == CSVFormat.TRANSTYPE_SALE)
                {
                    newTrans.TransactionType = TransType.SALE;
                }
                else if (dataDict[CSVFields.TRANS_TYPE.ToString()] == CSVFormat.TRANSTYPE_REFUND)
                {
                    newTrans.TransactionType = TransType.REFUND;
                }
                else
                {
                    throw new ArgumentException("Invalid transaction type.");
                }
                // Merchant Id
                newTrans.MerchantId = dataDict[CSVFields.MERCHANT_ID.ToString()];
                // Card No
                newTrans.CardNo = dataDict[CSVFields.CARD_NO.ToString()];
                // Expired Date
                newTrans.ExpireDate = dataDict[CSVFields.EXPIRED_DATE.ToString()];
                // Transaction Amount
                try
                {
                    newTrans.TransactionAmount = FormatterService.Instance.StringToDecimal(dataDict[CSVFields.TRANS_AMT.ToString()], 2);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction amount");
                }
                // Transaction Date
                try
                {
                    newTrans.TransactionDate = FormatterService.Instance.StringToDate(dataDict[CSVFields.TRANS_DATE.ToString()]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction date");
                }
                // Transaction Time
                try
                {
                    newTrans.TransactionTime = FormatterService.Instance.StringToTime(dataDict[CSVFields.TRANS_TIME.ToString()]);
                }
                catch (FormatException)
                {
                    throw new FormatException("Invalid transaction time");
                }
                // CardType
                if (dataDict[CSVFields.CARD_TYPE.ToString()] == CSVFormat.CARDTYPE_MASTER)
                {
                    newTrans.CardType = CardType.MASTER;
                }
                else if (dataDict[CSVFields.CARD_TYPE.ToString()] == CSVFormat.CARDTYPE_VISA)
                {
                    newTrans.CardType = CardType.VISA;
                }
                else if (dataDict[CSVFields.CARD_TYPE.ToString()] == CSVFormat.CARDTYPE_JCB)
                {
                    newTrans.CardType = CardType.JCB;
                }
                else if (dataDict[CSVFields.CARD_TYPE.ToString()] == CSVFormat.CARDTYPE_UNIONPAY)
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
                throw new KeyNotFoundException("Missing fields from CSV file.");
            }
            return newTrans;
        }
    }
}

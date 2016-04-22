using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLoaderBase;

namespace CyberMarsConverter
{
    class CyberMarsConverter : IConverter
    {

        public string filePath { get; set; }
        public CyberMarsConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Transaction> Convert()
        {
            string[] data = FileReadService.Instance.ReadTextFileIntoStringArray(this.filePath);
            List<Transaction> transList = new List<Transaction>();

            if (data.Length == 0)
            {
                throw new Exception("Empty file.");
            }

            foreach (string dataUnit in data)
            {
                this.Validate(dataUnit);
                List<string> dataList = Parse(dataUnit);
                transList.Add(this.GetTransaction(dataList));
            }
            return transList;
        }

        private void Validate(string data)
        {
            if (data.Length != CyberMarsFormat.TOTAL_LENGTH)
            {
                throw new ArgumentException("Invalid data length.");
            }
            return;
        }

        private List<string> Parse(string data)
        {
            List<string> dataList = new List<string>();
            dataList.Add(data.Substring(0, CyberMarsFormat.SEQ_LENGTH));
            data = data.Remove(0, CyberMarsFormat.SEQ_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.TRANSACTION_TYPE_LENGTH));
            data = data.Remove(0, CyberMarsFormat.TRANSACTION_TYPE_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.MERCHANT_ID_LENGTH));
            data = data.Remove(0, CyberMarsFormat.MERCHANT_ID_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.CARD_NO_LENGTH));
            data = data.Remove(0, CyberMarsFormat.CARD_NO_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.EXPIRE_DATE_LENGTH));
            data = data.Remove(0, CyberMarsFormat.EXPIRE_DATE_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.TRANSACTION_AMOUNT_LENGTH));
            data = data.Remove(0, CyberMarsFormat.TRANSACTION_AMOUNT_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.TRANSACTION_DATE_LENGTH));
            data = data.Remove(0, CyberMarsFormat.TRANSACTION_DATE_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.TRANSACTION_TIME_LENGTH));
            data = data.Remove(0, CyberMarsFormat.TRANSACTION_TIME_LENGTH);
            dataList.Add(data.Substring(0, CyberMarsFormat.CARD_TYPE_LENGTH));
            data = data.Remove(0, CyberMarsFormat.CARD_TYPE_LENGTH);
            return dataList;
        }

        private Transaction GetTransaction(List<string> dataList)
        {
            Transaction newTrans = new Transaction();
            // SEQ
            newTrans.SEQ = dataList[0];
            // Transaction Type
            if(dataList[1] == CyberMarsFormat.TRANSTYPE_SALE)
            {
                newTrans.TransactionType = TransType.SALE;
            }
            else if (dataList[1] == CyberMarsFormat.TRANSTYPE_REFUND)
            {
                newTrans.TransactionType = TransType.REFUND;
            }
            else
            {
                throw new ArgumentException("Invalid transaction type.");
            }
            // Merchant Id
            newTrans.MerchantId = dataList[2];
            // Card No
            newTrans.CardNo = dataList[3];
            // Expired Date
            newTrans.ExpireDate = dataList[4];
            // Transaction Amount
            try
            {
                newTrans.TransactionAmount = FormatterService.Instance.StringToDecimal(dataList[5], 2);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid transaction amount");
            }
            // Transaction Date
            try
            {
                newTrans.TransactionDate = FormatterService.Instance.StringToDate(dataList[6]);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid transaction date");
            }
            // Transaction Time
            try
            {
                newTrans.TransactionTime = FormatterService.Instance.StringToTime(dataList[7]);
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid transaction time");
            }
            // CardType
            if(dataList[8]==CyberMarsFormat.CARDTYPE_MASTER)
            {
                newTrans.CardType = CardType.MASTER;
            }
            else if (dataList[8] == CyberMarsFormat.CARDTYPE_VISA)
            {
                newTrans.CardType = CardType.VISA;
            }
            else if (dataList[8] == CyberMarsFormat.CARDTYPE_JCB)
            {
                newTrans.CardType = CardType.JCB;
            }
            else if (dataList[8] == CyberMarsFormat.CARDTYPE_UNIONPAY)
            {
                newTrans.CardType = CardType.UNIONPAY;
            }
            else
            {
                throw new ArgumentException("Invalid card type.");
            }
            return newTrans;
        }  
    }
}

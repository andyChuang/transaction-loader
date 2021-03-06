﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionLoaderBase;

namespace CsvConverter
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
            List<string> data = FileReadService.Instance.ReadTextFileIntoStringArray(this.filePath).ToList();
            List<Transaction> transList = new List<Transaction>();

            if (data.Count == 0)
            {
                throw new CustomException("Empty file.");
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
                throw new CustomException("Field count of header and data are not matched.");
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
                newTrans.SEQ = dataDict[CsvFields.DATA_SEQ];
                // Transaction Type
                if (dataDict[CsvFields.TRANS_TYPE] == CsvFormat.TRANSTYPE_SALE)
                {
                    newTrans.TransactionType = TransType.SALE;
                }
                else if (dataDict[CsvFields.TRANS_TYPE] == CsvFormat.TRANSTYPE_REFUND)
                {
                    newTrans.TransactionType = TransType.REFUND;
                }
                else
                {
                    throw new CustomException("Invalid transaction type.");
                }
                // Merchant Id
                newTrans.MerchantId = dataDict[CsvFields.MERCHANT_ID];
                // Card No
                newTrans.CardNo = dataDict[CsvFields.CARD_NO];
                // Expired Date
                newTrans.ExpireDate = dataDict[CsvFields.EXPIRED_DATE];
                // Transaction Amount
                try
                {
                    newTrans.TransactionAmount = FormatterService.Instance.StringToDecimal(dataDict[CsvFields.TRANS_AMT], 2);
                }
                catch (FormatException)
                {
                    throw new CustomException("Invalid transaction amount");
                }
                // Transaction Date
                try
                {
                    newTrans.TransactionDate = FormatterService.Instance.StringToDate(dataDict[CsvFields.TRANS_DATE]);
                }
                catch (FormatException)
                {
                    throw new CustomException("Invalid transaction date");
                }
                // Transaction Time
                try
                {
                    newTrans.TransactionTime = FormatterService.Instance.StringToTime(dataDict[CsvFields.TRANS_TIME]);
                }
                catch (FormatException)
                {
                    throw new CustomException("Invalid transaction time");
                }
                // CardType
                if (dataDict[CsvFields.CARD_TYPE] == CsvFormat.CARDTYPE_MASTER)
                {
                    newTrans.CardType = CardType.MASTER;
                }
                else if (dataDict[CsvFields.CARD_TYPE] == CsvFormat.CARDTYPE_VISA)
                {
                    newTrans.CardType = CardType.VISA;
                }
                else if (dataDict[CsvFields.CARD_TYPE] == CsvFormat.CARDTYPE_JCB)
                {
                    newTrans.CardType = CardType.JCB;
                }
                else if (dataDict[CsvFields.CARD_TYPE] == CsvFormat.CARDTYPE_UNIONPAY)
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
                throw new CustomException("Missing fields from CSV file.");
            }
            return newTrans;
        }
    }
}

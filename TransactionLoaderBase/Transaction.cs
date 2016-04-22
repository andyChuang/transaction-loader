namespace TransactionLoaderBase
{
    using System;

    public class Transaction
    {
        /// <summary>
        /// 交易流水號
        /// </summary>
        public string SEQ { get; set; }

        /// <summary>
        /// 刷卡特店代號
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 卡號
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 卡別
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// 交易類型
        /// </summary>
        public TransType TransactionType { get; set; }

        /// <summary>
        /// 卡片到期日
        /// </summary>
        public string ExpireDate { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        public DateTime TransactionTime { get; set; }
    }
}
using System;
using Seun_s_Bank.Data;

namespace Seun_s_Bank
{
    public class Transaction
    {
        //properties
        #region properties
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string acc { get; set; }
        public DateTime date { get; set; }
        #endregion

        #region Transaction Constructor
        public Transaction(string accountNumber, decimal amount, string note, string acc, DateTime date)
        {
            Id = createId();
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
            Amount = amount;
            Note = note ?? throw new ArgumentNullException(nameof(note));
            this.acc = acc ?? throw new ArgumentNullException(nameof(acc));
            this.date = date;
        }
        #endregion

        private string createId()
        {
            int transactions = Bank.allTransactions.Count + 1;
            foreach (var transaction in Bank.allTransactions)
            {
                if (transactions == Convert.ToInt32(transaction.Id))
                    transactions += 1;
            }

            return transactions.ToString();
        }
    }
}

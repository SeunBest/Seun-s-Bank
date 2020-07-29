using System;
using System.Collections.Generic;
using System.Text;

namespace Seun_s_Bank
{
    class Transaction
    {
        public Customer Owner { get; set; }
        public int AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
        public DateTime TimeStamp { get; set; }

        public Transaction(Customer owner, int accountNumber, decimal amount, decimal balance, string note, DateTime timeStamp)
        {
            Owner = owner;
            AccountNumber = accountNumber;
            Amount = amount;
            Balance = balance;
            Note = note;
            TimeStamp = timeStamp;
        }
    }
}

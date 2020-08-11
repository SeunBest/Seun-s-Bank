using System;
using System.Collections.Generic;
using Seun_s_Bank.Data;

namespace Seun_s_Bank.Lib
{
    public class Account : IDuty
    {
        #region Properties
        //base number for account number generstion
        int seed = 1234567890;
        public string number { get; private set; }
        public typeOfAcc AccType { get; set; }
        public string OwnerID { get; set; }
        public DateTime date { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transact in Bank.allTransactions)
                {
                    if (this.number == transact.AccountNumber)
                    {
                        balance += transact.Amount;
                    }
                }
                return balance;
            }
        }

        public List<Transaction> Transactions
        {
            get
            {
                var trans = new List<Transaction>();
                foreach (var transact in Bank.allTransactions)
                {
                    if (this.number == transact.AccountNumber)
                    {
                        trans.Add(transact);
                    }
                }
                return trans;
            }
            set { }
        }
        #endregion

        #region account constructor
        public Account() { }
        public Account(string ownerID, typeOfAcc accType, decimal startUp)
        {
            seed += _numberOfAccounts();
            number = seed.ToString();
            OwnerID = ownerID;
            this.AccType = accType;
            Transactions = new List<Transaction>();
            date = DateTime.Now;
        }
        #endregion

        #region Deposit Method
        public void Deposit(decimal amount, string note)
        {
            //handle invalid amount
           if (amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be above zero");
            }
            //make the deposit
            var cash = new Transaction(this.number, amount, note, this.AccType.ToString(), DateTime.Now);
            //add transaction to transactions
            Bank.allTransactions.Add(cash);
        }
        #endregion

        #region Withdraw Method
        public void Withdraw(decimal amount, string note)
        {
            //handle invalid amount
            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal must be above zero");
            }

            //handle savings account
            if (this.AccType.ToString() == "Savings" && Balance - amount < 100)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }

            //handle current account
            if (this.AccType.ToString() == "Current" && Balance - amount < 1000)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }

            //Make withdrawal
            var drawn = new Transaction(this.number, -amount, note, this.AccType.ToString(), DateTime.Now);
            //Add withdrawal to transactions 
            Bank.allTransactions.Add(drawn);
        }
        #endregion

        #region Transfer Method
        public void Transfer(string accNo, decimal amount, string note)
        {
            //variable that tracks if recipient acc. No. exists
            bool found = false;
            //instantiate the recipient
            var recipient = new Account();
            //search for the recipient
            for (int i = 0; i < Bank.allAccounts.Count; i++)
            {
                if (accNo == Bank.allAccounts[i].number)
                {
                    //get recipient
                    found = true;
                    recipient = Bank.allAccounts[i];
                    break;
                }
            }
            //for case of an invalid recipient
            if (!found)
            {
                throw new InvalidOperationException($"{accNo} was not found");
            } else
            //for valid recipient
            {
                this.Withdraw(amount, $"transfer to {accNo}");
                recipient.Deposit(amount,  $"transfer from {this.number}");
            }
        }
        #endregion

        private int _numberOfAccounts()
        {
            return 1 + Bank.allAccounts.Count;
        }
    }
}

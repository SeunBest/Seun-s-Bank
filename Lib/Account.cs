using Seun_s_Bank.Lib;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Seun_s_Bank.Data;

namespace Seun_s_Bank.Lib
{
    public class Account : IDuty
    {
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

        public Account() { }
        public Account(string ownerID, typeOfAcc accType, decimal startUp)
        {
            seed += _numberOfAccounts();
            number = seed.ToString();
            OwnerID = ownerID;
            this.AccType = accType;
            Transactions = new List<Transaction>();
            date = DateTime.Now;
            Deposit(number, startUp, "Opening Balance", accType);
        }

        public void Deposit(string accNo, decimal amount, string note, typeOfAcc acc)
        {
            //handle invalid amount
           if (amount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be above zero");
            }
            //make the deposit
            var cash = new Transaction(accNo, amount, note, acc.ToString(), DateTime.Now);
            //add transaction to transactions
            Bank.allTransactions.Add(cash);
        }

        public void Withdraw(string accNo, decimal amount, string note, typeOfAcc acc)
        {
            //handle invalid amount
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal must be above zero");
            }

            //handle savings account
            if (acc.ToString() == "Savings" && Balance - amount < 100)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }

            //handle current account
            if (acc.ToString() == "Current" && Balance - amount < 1000)
            {
                throw new InvalidOperationException("Insufficient Funds");
            }

            //Make withdrawal
            var drawn = new Transaction(accNo, -amount, note, acc.ToString(), DateTime.Now);
            //Add withdrawal to transactions 
            Bank.allTransactions.Add(drawn);
        }

        public void Transfer(string accNo, decimal amount, string note, typeOfAcc acc)
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
                throw new InvalidOperationException("Insufficient Funds");
            } else
            //for valid recipient
            {
                this.Withdraw(this.number, -amount, $"transfer to {accNo}", this.AccType);
                recipient.Deposit(recipient.number, amount,  $"transfer from {this.number}", recipient.AccType);
            }
        }


        private int _numberOfAccounts()
        {
            return 1 + Bank.allAccounts.Count;
        }
    }
}

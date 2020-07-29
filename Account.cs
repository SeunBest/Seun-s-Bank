using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Seun_s_Bank
{
    public class Account
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public int Accountnumber { get; set; }
        public string Owner { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public string DateCreated { get; set; }
        public string Account_type { get; set; }


        public Account( int customer_id, string owner, string acct_type )
        {
            Random num = new Random();

            this.Id = num.Next(1000000, 9000000);
            this.Customer_id = customer_id;
            this.Accountnumber = num.Next(1000, 3000);
            this.Owner = owner;
            this.Account_type = acct_type;
            this.DateCreated = DateTime.Now.ToString("MM/dd/yyyy");
            this.Note = "Account created";
            this.Amount = 0;
        }

        public void Withdraw(decimal amount)
        {
           if (amount < 1)
            {
                Console.WriteLine("can not withdraw an amount less than one");
            } else if (amount > (Amount - 100))
            {
                Amount -= amount;
            }
            {
                Console.WriteLine("balance must have at least");
            }
        }

        public void Deposit()
        {

        }
    }
}

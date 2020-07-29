using System;
using System.Collections.Generic;
using System.Text;

namespace Seun_s_Bank
{
    public class Account
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public int Accountnumber { get; set; }
        public string Owner { get; set; }
        public double Amount { get; set; }
        public string Note { get; set; }
        public string DateCreated { get; set; }
        public string Account_type { get; set; }


        public Account( int customer_id, string owner, string acct_type )
        {
            Random num = new Random();

            this.Id = num.Next(1, 100);
            this.Customer_id = customer_id;
            this.Accountnumber = num.Next(1000, 3000);
            this.Owner = owner;
            this.Account_type = acct_type;
            this.DateCreated = DateTime.Now.ToString("MM/dd/yyyy");
            this.Note = " Account created";



        }
    }
}

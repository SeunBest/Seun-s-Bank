using System;
using System.Collections.Generic;
using System.Text;

namespace Seun_s_Bank
{
    class Bank
    {
        public int Id { get; set; }
        public int Accountnumber { get; set; }
        public string email { get; set; }

        public List<Transaction> allTransactions = new List<Transaction>();
        public List<Customer> allCustomers = new List<Customer>();
        public List<Account> allAccounts = new List<Account>();

        public void AddCustomer(Customer customer)
        {
            allCustomers.Add(customer);
        }
    }
}

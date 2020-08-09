using System;
using System.Collections.Generic;
using System.Text;
using Seun_s_Bank.Lib;

namespace Seun_s_Bank.Data
{
    public static class Bank
    {
        public static List<Transaction> allTransactions { get; set; } = new List<Transaction>();
        public static List<Customer> allCustomers { get; set; } = new List<Customer>();
        public static List<Account> allAccounts { get; set; } = new List<Account>();
    }
}

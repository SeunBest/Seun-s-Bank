using System;
using System.Collections.Generic;
using System.Text;
using Seun_s_Bank.Lib;
using Seun_s_Bank.Data;

namespace Seun_s_Bank.Lib
{
    public interface IDuty
    {
        public void Deposit(string accNum, decimal amt, string note, typeOfAcc acc);

        public void Withdraw(string accNum, decimal amt, string note, typeOfAcc acc);
    }
}

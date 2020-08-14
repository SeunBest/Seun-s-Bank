using NUnit.Framework;
using Seun_s_Bank.Lib;
using Seun_s_Bank.Data;
using Seun_s_Bank.Help;
using System;

namespace BankNunit.Tests
{
    public class Tests
    {
        public string Name { get; private  set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public  typeOfAcc Type { get; private set; }
        public decimal  Balance { get; private set; }

        [SetUp]
        public void Setup()
        {

            Name = "Seun";
            Password = "ask";
            Email = "werock@you.com";
            Type = typeOfAcc.Savings;
            Balance = 2000;
        }

        [Test]
        public void testRegister()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);
           
            //Assert
            Assert.That(acs, Is.Not.EqualTo(null));

        }

        [Test]
        public void testLogin()
        {
            //Arrange
            Sessions.Register(Name, Email, Password, Type, Balance);
            var acs = Sessions.Login(Email, Password);

            //Assert
            Assert.That(Sessions.status, Is.EqualTo(true));

        }

        [Test]
        public void testInvalidDepositException()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);
            //var acs = Sessions.Login(Email, Password);

            //Assert
            Assert.That(() => acs.Deposit(0, "zero deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void testDeposit()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);

            //Act
            acs.Deposit(3000, "data sale");

            //Assert
            Assert.That(acs.Balance, Is.EqualTo(5000));
        }

        [Test]
        public void testInvalidWithdrawalException()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);

            //Assert
            Assert.That(() => acs.Withdraw(0, "zero deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void testInsufficientSavings()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);

            //Assert
            Assert.That(() => acs.Withdraw(2950, "min deposit"), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void testInsufficientCurrent()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, Balance);

            //Assert
            Assert.That(() => acs.Withdraw(1950, "min deposit"), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void testWithdraw()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, 10000);

            //Act
            acs.Withdraw(3000, "internet sub");

            //Assert
            Assert.That(acs.Balance, Is.EqualTo(7000));
        }

        [Test]
        public void testTransferDebit()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, 20000);
            var cus = Sessions.Register("Daniel", "come@me.com", "encreepted", typeOfAcc.Current, 5000);

            //Act
            acs.Transfer(cus.number, 10000, "Headset Payment");

            //Assert
            Assert.That(acs.Balance, Is.EqualTo(10000));
        }

        [Test]
        public void testTransferCredit()
        {
            //Arrange
            var acs = Sessions.Register(Name, Email, Password, Type, 20000);
            var cus = Sessions.Register("Daniel", "come@me.com", "encreepted", typeOfAcc.Current, 5000);

            //Act
            acs.Transfer(cus.number, 10000, "Headset Payment");

            //Assert
            Assert.That(cus.Balance, Is.EqualTo(15000));
        }

        [Test]
        public void testTransactions()
        {
            //Arrange
            int before = Bank.allTransactions.Count;
            var acs = Sessions.Register(Name, Email, Password, Type, 10000);
            
            //Act
            acs.Withdraw(3000, "internet sub");
            acs.Deposit(1000, "atm refund");

            int after = Bank.allTransactions.Count;
            int addedTransactions = after - before;

            //Assert
            Assert.That(addedTransactions, Is.EqualTo(3));
        }

    }
}
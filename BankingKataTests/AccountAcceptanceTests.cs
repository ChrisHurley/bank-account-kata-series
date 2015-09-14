using BankingKata;
using NUnit.Framework;
using System;

namespace BankingKataTests
{
    [TestFixture]
    public class AccountAcceptanceTests
    {
        [Test]
        public void DepositingCashIncreasesTheAccountBalance()
        {
            var account = new Account();

            account.Deposit(DateTime.Now, new Money(5.00m));

            Money expected = new Money(5.00m);
            Assert.That(account.CalculateBalance(), Is.EqualTo(expected));
        }

        [Test]
        public void WithdrawingCashDecreasesTheAccountBalance()
        {
            var account = new Account();
            account.Deposit(DateTime.Now, new Money(6m));
            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(2m));
            account.Withdraw(debitEntry);

            var expectedBalance = new Money(4m);
            Assert.That(account.CalculateBalance(), Is.EqualTo(expectedBalance));
        }

        [Test]
        public void WithdrawingMoreThanOverdraftLimitThrowsException()
        {
            var accountWithOverdraft = new AccountWithOverdraft(new Account(), new UnarrangedOverdraft(new Money(-1000m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(1001m));
            Assert.Throws<OverdraftLimitReachedException>(() => accountWithOverdraft.Withdraw(debitEntry));
        }

        [Test]
        public void WithdrawingLessThanOverdraftLimitDoesNotThrowsException()
        {
            var accountWithOverdraft = new AccountWithOverdraft(new Account(), new UnarrangedOverdraft(new Money(-1000m)));

            var debitEntry = new ATMDebitEntry(DateTime.Now, new Money(999m));
            Assert.DoesNotThrow(() => accountWithOverdraft.Withdraw(debitEntry));
        }
    }
}

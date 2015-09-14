using System;

namespace BankingKata
{
    public class AccountWithOverdraft : IAccount
    {
        private readonly IAccount m_Account;
        private readonly Money m_OverdraftLimit;

        public AccountWithOverdraft(IAccount account, Money overdraftLimit)
        {
            m_Account = account;
            m_OverdraftLimit = overdraftLimit;
        }

        public void Withdraw(DebitEntry debitEntry)
        {
            var balanceAfterWithdrawal = debitEntry.ApplyTo(CalculateBalance());

            if (balanceAfterWithdrawal < m_OverdraftLimit)
            {
                throw new OverdraftLimitReachedException();
            }

            m_Account.Withdraw(debitEntry);
        }

        public void Deposit(DateTime transactionDate, Money money)
        {
            m_Account.Deposit(transactionDate, money);
        }

        public Money CalculateBalance()
        {
            return m_Account.CalculateBalance();
        }

        public void PrintBalance(IPrinter printer)
        {
            m_Account.PrintBalance(printer);
        }

        public void PrintLastTransaction(IPrinter printer)
        {
            m_Account.PrintLastTransaction(printer);
        }

    }
}
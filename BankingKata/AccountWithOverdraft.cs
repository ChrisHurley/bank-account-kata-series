using System;

namespace BankingKata
{
    public class AccountWithOverdraft : IAccount
    {
        private readonly IAccount m_Account;
        private readonly Money m_Money;

        public AccountWithOverdraft(IAccount account, Money money)
        {
            m_Account = account;
            m_Money = money;
        }

        public void Withdraw(DebitEntry debitEntry)
        {
            var balanceAfterWithdrawal = debitEntry.ApplyTo(CalculateBalance());

            if (balanceAfterWithdrawal < m_Money)
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
using System;

namespace BankingKata
{
    public class CheckDebitEntry : DebitEntry
    {
        private readonly CheckNumber m_CheckNumber;

        public CheckDebitEntry(DateTime now, Money money, CheckNumber checkNumber):base(now, money)
        {
            m_CheckNumber = checkNumber;
        }
    }
}
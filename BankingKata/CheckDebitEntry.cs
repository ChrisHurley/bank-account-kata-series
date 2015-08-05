using System;

namespace BankingKata
{
    public class CheckDebitEntry : DebitEntry
    {
        public CheckDebitEntry(DateTime now, Money money):base(now, money)
        {
           
        }
    }
}
﻿using System;

namespace BankingKata
{
    public class CashDebitEntry : DebitEntry
    {
        public CashDebitEntry(DateTime now, Money money) :base(now, money)
        {
           
        }

        public override string ToString()
        {
            return $"ATM {base.ToString()}";
        }
    }
}
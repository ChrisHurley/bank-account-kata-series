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

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"CHQ {m_CheckNumber} {base.ToString()}";
        }
    }
}
namespace BankingKata
{
    public class CheckNumber
    {
        private readonly int m_CheckNumber;

        public CheckNumber(int checkNumber)
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
            return $"{m_CheckNumber:D6}";
        }
    }
}
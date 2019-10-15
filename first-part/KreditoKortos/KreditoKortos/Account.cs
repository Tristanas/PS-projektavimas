namespace KreditoKortos
{
    public class Account
    {
        public string iban;
        public Currency usedCurrency;
        private float sum;

        public Account(string iban, Currency currency, float initialDeposit = 0)
        {
            this.iban = iban;
            this.usedCurrency = currency;
            sum = initialDeposit;
        }

        public void deposit(float sum)
        {
            this.sum += sum;
        }

        /// <summary>
        /// Attempts to withdraw money from the account.
        /// </summary>
        /// <param name="sum">amount of money to withraw</param>
        /// <returns>True if withrawal succeeded, false if there wasn't enough money.</returns>
        public bool withraw(float sum)
        {
            if (sum > this.sum)
            {
                return false;
            }
            this.sum -= sum;
            return true;
        }

        public float getSum()
        {
            return this.sum;
        }
    }
}
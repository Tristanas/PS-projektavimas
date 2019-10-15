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

        public bool withraw(float sum)
        {
            if (sum > this.sum)
            {
                return false;
            }
            this.sum -= sum;
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class MasterCardDepositless: CreditCard
    {
        public float transactionReturns = 0.01f;
        public MasterCardDepositless(Account account) : base(account)
        {
        }

        protected override string GetLoanDeposit()
        {
            return "";
        }

        protected override bool IsLoanDepositSuitable(string deposit)
        {
            return true;
        }

        protected override bool IsLoanPriceValid(float sum)
        {
            return sum > 100f && sum < 250000f;
        }

        /// <summary>
        /// Premium card holders are not taxed for foreign transactions. They actually get back a fraction of money transferred.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            return -sum * transactionReturns;
        }

        /// <summary>
        /// Master card owners do not pay for changing currency.
        /// </summary>
        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return 0;
        }

        protected override float MaximumWithrawalSum()
        {
            return 20000f;
        }

        // Master card owners can spend unlimited amounts of money each day.
        protected override bool PaymentLimitReached(float sumToPay)
        {
            return false;
        }

        /// Master card owners do not pay tax when withrawing money abroad.
        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return 0;
        }
    }
}

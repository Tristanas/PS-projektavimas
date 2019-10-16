using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class RegularCardDepositless : CreditCard
    {
        public RegularCardDepositless(Account account) : base(account)
        {
        }

        /// <summary>
        /// Uses account iban to check whether both accounts are from the same country. 
        /// If not, applies a tax equal to 5% of transfered sum.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            if (this.account.iban.Contains(recipient.iban.Substring(0, 2)))
            {
                return 0;
            }
            return 0.05f * sum;
        }

        /// <summary>
        /// Calculates the tax for currency change when withrawing or transferring money.
        /// </summary>
        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return initialCurrency.Name == targetCurrency.Name ? 0 : sum * 0.04f;
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
            return sum > 100f && sum < 5000f;
        }

        protected override float MaximumWithrawalSum()
        {
            return 300f;
        }

        protected override bool PaymentLimitReached(float sumToPay)
        {
            return this.currentDayExpenses + sumToPay > 500f;
        }

        /// <summary>
        /// Calculates tax for withrawing money depending on country where the operation is carried out.
        /// </summary>
        /// <param name="ATMCountry">where the ATM is located</param>
        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return this.account.iban.StartsWith(ATMCountry) ? 0 : Math.Min(sum * 0.05f, 20f);
        }
    }
}

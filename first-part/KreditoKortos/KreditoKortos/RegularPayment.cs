using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class RegularPayment
    {
        public float MaximumWithrawalSum()
        {
            return 300f;
        }

        public bool PaymentLimitReached(CreditCard card, float sumToPay)
        {
            return card.currentDayExpenses + sumToPay > 500f;
        }

        /// <summary>
        /// Calculates tax for withrawing money depending on country where the operation is carried out.
        /// </summary>
        /// <param name="ATMCountry">where the ATM is located</param>
        public float WithrawalTax(float sum, string ATMCountry, Account account)
        {
            return account.iban.StartsWith(ATMCountry) ? 0 : Math.Min(sum * 0.05f, 20f);
        }

        /// <summary>
        /// Uses account iban to check whether both accounts are from the same country. 
        /// If not, applies a tax equal to 5% of transfered sum.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        public float CalculateTransactionTax(float sum, Account recipient, Account account)
        {
            if (account.iban.Contains(recipient.iban.Substring(0, 2)))
            {
                return 0;
            }
            return 0.05f * sum;
        }

        /// <summary>
        /// Calculates the tax for currency change when withrawing or transferring money.
        /// </summary>
        public float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return initialCurrency.Name == targetCurrency.Name ? 0 : sum * 0.04f;
        }
    }
}

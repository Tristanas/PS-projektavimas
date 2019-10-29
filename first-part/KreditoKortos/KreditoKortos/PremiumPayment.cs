using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class PremiumPayment
    {
        /// <summary>
        /// Premium card holders are not taxed for foreign transactions.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        public float CalculateTransactionTax(float sum, Account recipient)
        {
            return 0;
        }

        /// <summary>
        /// Calculates the tax for currency change when withrawing or transferring money.
        /// </summary>
        public float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return initialCurrency.Name == targetCurrency.Name ? 0 : sum * 0.02f;
        }

        public float MaximumWithrawalSum()
        {
            return 1000f;
        }

        public bool PaymentLimitReached(float sumToPay, CreditCard card)
        {
            return card.currentDayExpenses + sumToPay > 2000f;
        }

        /// <summary>
        /// Calculates tax for withrawing money depending on country where the operation is carried out.
        /// </summary>
        /// <param name="ATMCountry">where the ATM is located</param>
        public float WithrawalTax(float sum, string ATMCountry, CreditCard card)
        {
            return card.account.iban.StartsWith(ATMCountry) ? 0 : Math.Min(sum * 0.02f, 20f);
        }
    }
}

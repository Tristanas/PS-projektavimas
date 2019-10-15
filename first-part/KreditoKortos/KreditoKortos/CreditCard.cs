using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    abstract class CreditCard
    {
        public float currentDayExpenses;
        public Account account;

        public CreditCard(Account account)
        {
            this.account = account;
            currentDayExpenses = 0;
        }

        /// <summary>
        /// Withraws money using the card at an ATM. Taxes may be applied if money of different currency is withrawn and/or in not native country.
        /// </summary>
        /// <param name="sum">How much cash to withdraw.</param>
        /// <param name="targetCurrency">Type of currency to withdraw.</param>
        /// <param name="ATMCountry">Abbreviation of the country in which the withrawal is carried out.</param>
        /// <returns>True if withrawal was successful, false otherwise.</returns>
        public bool WithrawMoney(float sum, Currency targetCurrency, string ATMCountry)
        {
            float transactionCost = 0;
            float costInOwnCurrency = Currency.ConvertCurrency(sum, targetCurrency, this.account.usedCurrency);
            if (targetCurrency.Name != this.account.usedCurrency.Name)
            {
                transactionCost += CurrencyChangeTax(sum, this.account.usedCurrency, targetCurrency);
            }

            transactionCost += withrawalTax(costInOwnCurrency, ATMCountry);
            transactionCost += costInOwnCurrency;

            if (!PaymentLimitReached(transactionCost) && costInOwnCurrency < MaximumWithrawalSum())
            {
                return this.account.withraw(transactionCost);
            }
            return false;
        }

        /// <summary>
        /// Reduces the sum stored in the account by the sum converted to own currency if recipient operates in another currency.
        /// </summary>
        /// <param name="sum">amount of money to be transfered to another account. Type of currency - one that recipient operates in.</param>
        /// <param name="recipient">the account to which the sum will be transfered</param>
        public void TransferMoney(float sum, Account recipient)
        {

        }

        abstract protected bool PaymentLimitReached(float sumToPay);
        abstract protected float CalculateTransactionTax(float sum, Account recipient);
        abstract protected float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency);
        abstract protected float MaximumWithrawalSum();
        abstract protected float withrawalTax(float sum, string ATMCountry);
    }
}

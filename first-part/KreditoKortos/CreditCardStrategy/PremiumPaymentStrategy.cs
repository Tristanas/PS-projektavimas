using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    class PremiumPaymentStrategy: IPaymentStrategy
    {
        public float MaximumWithrawalSum = 600f;
        public float DailyTransactionLimit = 2000f;
        public float CurrencyConversionTaxRate = 0.02f;
        public float ForeignTransactionTaxRate = 0.01f;
        public float ForeignWithdrawalTaxRate = 0.025f;
        public float MaximumWithdrawalTax = 20f;

        public bool Withdraw(float sum, Currency targetCurrency, string ATMCountry, CreditCard card)
        {
            Account account = card.account;
            float costInOwnCurrency = Currency.ConvertCurrency(sum, targetCurrency, account.usedCurrency);
            float transactionCost = costInOwnCurrency;

            if (targetCurrency.Name != account.usedCurrency.Name)
            {
                transactionCost += costInOwnCurrency * CurrencyConversionTaxRate;
            }

            transactionCost += account.iban.StartsWith(ATMCountry) ? 0 : Math.Min(costInOwnCurrency * ForeignWithdrawalTaxRate, MaximumWithdrawalTax);

            if (card.currentDayExpenses + transactionCost < DailyTransactionLimit && costInOwnCurrency < MaximumWithrawalSum)
            {
                return account.withraw(transactionCost);
            }
            return false;
        }

        /// <summary>
        /// Transfers money to a recipient account.
        /// </summary>
        /// <param name="sum">amount of money to be transfered to another account. Type of currency - one that recipient operates in.</param>
        /// <param name="recipient">the account to which the sum will be transfered.</param>
        /// <returns>True if transfer succeeded, false otherwise.</returns>
        public bool Transfer(float sum, Account recipient, CreditCard card)
        {
            Account account = card.account;
            float costInOwnCurrency = Currency.ConvertCurrency(sum, recipient.usedCurrency, account.usedCurrency);
            float transactionCost = costInOwnCurrency;

            if (recipient.usedCurrency.Name != account.usedCurrency.Name)
            {
                transactionCost += costInOwnCurrency * CurrencyConversionTaxRate;
            }

            transactionCost += account.iban.Contains(recipient.iban.Substring(0, 2)) ? 0 : ForeignTransactionTaxRate * costInOwnCurrency;

            if (card.currentDayExpenses + transactionCost < DailyTransactionLimit)
            {
                if (account.withraw(transactionCost))
                {
                    recipient.deposit(sum);
                    return true;
                }
            }
            return false;
        }
    }
}

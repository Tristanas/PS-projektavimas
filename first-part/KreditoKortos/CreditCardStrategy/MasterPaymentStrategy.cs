using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    class MasterPaymentStrategy: IPaymentStrategy
    {
        public float MaximumWithrawalSum = 5000f;
        public float DailyTransactionLimit = 10000f;
        public float GlobalDiscountPercentage = 0.01f;

        public bool Withdraw(float sum, Currency targetCurrency, string ATMCountry, CreditCard card)
        {
            Account account = card.account;
            float costInOwnCurrency = Currency.ConvertCurrency(sum, targetCurrency, account.usedCurrency);
            float transactionCost = costInOwnCurrency;

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

            transactionCost -= costInOwnCurrency * GlobalDiscountPercentage;

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

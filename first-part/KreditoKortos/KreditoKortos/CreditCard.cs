using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public abstract class CreditCard
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

            transactionCost += WithrawalTax(costInOwnCurrency, ATMCountry);
            transactionCost += costInOwnCurrency;

            if (!PaymentLimitReached(transactionCost) && costInOwnCurrency < MaximumWithrawalSum())
            {
                return this.account.withraw(transactionCost);
            }
            return false;
        }

        /// <summary>
        /// Transfers money to a recipient account.
        /// </summary>
        /// <param name="sum">amount of money to be transfered to another account. Type of currency - one that recipient operates in.</param>
        /// <param name="recipient">the account to which the sum will be transfered.</param>
        /// <returns>True if transfer succeeded, false otherwise.</returns>
        public bool TransferMoney(float sum, Account recipient)
        {
            float transactionCost = 0;
            float costInOwnCurrency = Currency.ConvertCurrency(sum, recipient.usedCurrency, this.account.usedCurrency);
            if (recipient.usedCurrency.Name != this.account.usedCurrency.Name)
            {
                transactionCost += CurrencyChangeTax(sum, this.account.usedCurrency, recipient.usedCurrency);
            }

            transactionCost += costInOwnCurrency + CalculateTransactionTax(sum, recipient);

            if (!PaymentLimitReached(transactionCost))
            {
                if (this.account.withraw(transactionCost))
                {
                    recipient.deposit(sum);
                    return true;
                }
            }
            return false;
        }

        public void GetALoan(float sum)
        {
            if (IsLoanPriceValid(sum))
            {
                string deposit = GetLoanDeposit();
                Loan newLoan = new Loan(sum, deposit);
                if (IsLoanDepositSuitable(deposit))
                {
                    RequestLoan(newLoan);
                    return;
                }
            }
            Console.WriteLine("Invalid loan sum or deposit.");
        }

        private void RequestLoan(Loan loan)
        {
            if (this.account.setDebt(loan))
            {
                this.account.deposit(loan.sum);
                return;
            }
            Console.WriteLine("Unable to get a new loan, already in debt.");
        }

        abstract protected bool PaymentLimitReached(float sumToPay);
        abstract protected float CalculateTransactionTax(float sum, Account recipient);
        abstract protected float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency);
        abstract protected float MaximumWithrawalSum();
        abstract protected float WithrawalTax(float sum, string ATMCountry);
        //Should the loan be too little or too big, it should not be lended.
        abstract protected bool IsLoanPriceValid(float sum);
        abstract protected string GetLoanDeposit();
        abstract protected bool IsLoanDepositSuitable(string deposit);
    }
}

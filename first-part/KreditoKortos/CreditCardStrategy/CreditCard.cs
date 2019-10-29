using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    public class CreditCard
    {
        public float currentDayExpenses;
        public Account account;
        private IPaymentStrategy paymentStrategy;
        private ILoanStrategy loanStrategy;

        public CreditCard(Account account, IPaymentStrategy paymentStrategy = null, ILoanStrategy loanStrategy = null)
        {
            this.account = account;
            currentDayExpenses = 0;
            this.paymentStrategy = paymentStrategy != null ? paymentStrategy : new RegularPaymentStrategy();
            this.loanStrategy = loanStrategy != null ? loanStrategy : new LoanWithDepositStrategy();
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
            return paymentStrategy.Withdraw(sum, targetCurrency, ATMCountry, this);
        }

        /// <summary>
        /// Transfers money to a recipient account.
        /// </summary>
        /// <param name="sum">amount of money to be transfered to another account. Type of currency - one that recipient operates in.</param>
        /// <param name="recipient">the account to which the sum will be transfered.</param>
        /// <returns>True if transfer succeeded, false otherwise.</returns>
        public bool TransferMoney(float sum, Account recipient)
        {
            return paymentStrategy.Transfer(sum, recipient, this);
        }

        public void GetALoan(float sum)
        {
            loanStrategy.GetLoan(this, sum);
        }

        public void setPaymentStrategy(IPaymentStrategy strategy)
        {
            this.paymentStrategy = strategy;
        }

        public void setLoanStrategy(ILoanStrategy strategy)
        {
            this.loanStrategy = strategy;
        }
    }
}

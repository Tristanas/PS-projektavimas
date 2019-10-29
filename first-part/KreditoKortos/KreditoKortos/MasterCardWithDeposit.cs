using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class MasterCardWithDeposit : CreditCard
    {
        MasterPayment payment;
        LoanWithDeposit loan;
        public MasterCardWithDeposit(Account account) : base(account)
        {
            payment = new MasterPayment();
            loan = new LoanWithDeposit(100f, 250000f);
        }

        protected override string GetLoanDeposit()
        {
            return loan.GetLoanDeposit();
        }

        protected override bool IsLoanDepositSuitable(string deposit)
        {
            return loan.IsLoanDepositSuitable(deposit);
        }

        protected override bool IsLoanPriceValid(float sum)
        {
            return loan.IsLoanPriceValid(sum);
        }

        /// <summary>
        /// Premium card holders are not taxed for foreign transactions. They actually get back a fraction of money transferred.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            return payment.CalculateTransactionTax(sum, recipient);
        }

        /// <summary>
        /// Master card owners do not pay for changing currency.
        /// </summary>
        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return payment.CurrencyChangeTax(sum, initialCurrency, targetCurrency);
        }

        protected override float MaximumWithrawalSum()
        {
            return payment.MaximumWithrawalSum();
        }

        // Master card owners can spend unlimited amounts of money each day.
        protected override bool PaymentLimitReached(float sumToPay)
        {
            return payment.PaymentLimitReached(sumToPay);
        }

        /// Master card owners do not pay tax when withrawing money abroad.
        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return payment.WithrawalTax(sum, ATMCountry);
        }
    }
}

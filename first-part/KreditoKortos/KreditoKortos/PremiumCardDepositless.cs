using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class PremiumCardDepositless : CreditCard
    {
        PremiumPayment payment;
        LoanWithoutDeposit loan;
        public PremiumCardDepositless(Account account) : base(account)
        {
            payment = new PremiumPayment();
            loan = new LoanWithoutDeposit(100f, 20000f);
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

        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            return payment.CalculateTransactionTax(sum, recipient);
        }

        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return payment.CurrencyChangeTax(sum, initialCurrency, targetCurrency);
        }

        protected override float MaximumWithrawalSum()
        {
            return payment.MaximumWithrawalSum();
        }

        protected override bool PaymentLimitReached(float sumToPay)
        {
            return payment.PaymentLimitReached(sumToPay, this);
        }

        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return payment.WithrawalTax(sum, ATMCountry, this);
        }
    }
}

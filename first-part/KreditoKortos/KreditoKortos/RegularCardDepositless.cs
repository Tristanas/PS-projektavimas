using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class RegularCardDepositless : CreditCard
    {
        RegularPayment payment;
        LoanWithoutDeposit loan;
        public RegularCardDepositless(Account account) : base(account)
        {
            payment = new RegularPayment();
            loan = new LoanWithoutDeposit(100, 5000);
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

        protected override float MaximumWithrawalSum()
        {
            return payment.MaximumWithrawalSum();
        }

        protected override bool PaymentLimitReached(float sumToPay)
        {
            return payment.PaymentLimitReached(this, sumToPay);
        }

        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return payment.WithrawalTax(sum, ATMCountry, this.account);
        }

        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            if (this.account.iban.Contains(recipient.iban.Substring(0, 2)))
            {
                return 0;
            }
            return 0.05f * sum;
        }

        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return payment.CurrencyChangeTax(sum, initialCurrency, targetCurrency);
        }
    }
}

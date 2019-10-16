using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class PremiumCard : CreditCard
    {
        public PremiumCard(Account account) : base(account)
        {
        }
        protected override string GetLoanDeposit()
        {
            Console.WriteLine("You are required to make a deposit for the loan. Enter what property you deposit:");
            return Console.ReadLine();
        }

        protected override bool IsLoanDepositSuitable(string deposit)
        {
            return deposit == "house" || deposit == "car" || deposit == "forrest";
        }

        protected override bool IsLoanPriceValid(float sum)
        {
            return sum > 100f && sum < 20000f;
        }

        /// <summary>
        /// Premium card holders are not taxed for foreign transactions.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        protected override float CalculateTransactionTax(float sum, Account recipient)
        {
            return 0;
        }

        /// <summary>
        /// Calculates the tax for currency change when withrawing or transferring money.
        /// </summary>
        protected override float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return initialCurrency.Name == targetCurrency.Name ? 0 : sum * 0.02f;
        }

        protected override float MaximumWithrawalSum()
        {
            return 1000f;
        }

        protected override bool PaymentLimitReached(float sumToPay)
        {
            return this.currentDayExpenses + sumToPay > 2000f;
        }

        /// <summary>
        /// Calculates tax for withrawing money depending on country where the operation is carried out.
        /// </summary>
        /// <param name="ATMCountry">where the ATM is located</param>
        protected override float WithrawalTax(float sum, string ATMCountry)
        {
            return this.account.iban.StartsWith(ATMCountry) ? 0 : Math.Min(sum * 0.02f, 20f);
        }
    }
}

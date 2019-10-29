using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class MasterPayment
    {

        /// <summary>
        /// Premium card holders are not taxed for foreign transactions. They actually get back a fraction of money transferred.
        /// </summary>
        /// <param name="sum">amount of money transfered</param>
        /// <param name="recipient">Account to which the money is transfered</param>
        /// <returns></returns>
        public float CalculateTransactionTax(float sum, Account recipient)
        {
            return -sum * 0.01f;
        }

        /// <summary>
        /// Master card owners do not pay for changing currency.
        /// </summary>
        public float CurrencyChangeTax(float sum, Currency initialCurrency, Currency targetCurrency)
        {
            return 0;
        }

        public float MaximumWithrawalSum()
        {
            return 20000f;
        }

        // Master card owners can spend unlimited amounts of money each day.
        public bool PaymentLimitReached(float sumToPay)
        {
            return false;
        }

        /// Master card owners do not pay tax when withrawing money abroad.
        public float WithrawalTax(float sum, string ATMCountry)
        {
            return 0;
        }
    }
}

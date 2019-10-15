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

        public void WithrawMoney(float sum, Currency targetCurrency)
        {

        }

        // Of what currency should the sum be? 
        public void TransferMoney(float sum, Account recipient)
        {

        }

        // Should it be possible to pay in different currency than yours? 
        // Ex: your card is in pounds and you're paying for a dinner in greece using your card.
        public void PayWithCard(float sum)
        {

        }

        abstract protected bool PaymentLimitReached();
        abstract protected float CalculateTransactionTax();
        abstract protected float CurrencyChangeTax();
        abstract protected float MaximumWithrawalSum();
    }
}

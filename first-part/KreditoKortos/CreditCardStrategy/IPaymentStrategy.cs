using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    public interface IPaymentStrategy
    {
        bool Withdraw(float sum, Currency currency, string atmCountry, CreditCard card);
        bool Transfer(float sum, Account recipient, CreditCard card);
    }
}

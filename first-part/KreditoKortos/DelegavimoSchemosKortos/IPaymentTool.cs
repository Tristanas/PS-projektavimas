using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public interface IPaymentTool
    {
        bool Transfer(float sum, Account recipient, CreditCard card);
        bool Withdraw(float sum, Currency currency, string atmCountry, CreditCard card);
    }
}

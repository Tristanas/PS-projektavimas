using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public interface IOrderingTool
    {
        Order OrderCard();
        Order OrderItem(string name, float price, string originCountry, CreditCard creditCard);
    }
}

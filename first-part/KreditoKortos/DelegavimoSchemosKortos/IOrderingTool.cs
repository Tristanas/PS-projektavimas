using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public interface IOrderingTool
    {
        Order OrderCard(CreditCard card);
        Order OrderItem(string name, float price, string originCountry, CreditCard creditCard);
    }
}

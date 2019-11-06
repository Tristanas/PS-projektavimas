using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class MasterOrderingTool : OrderingTool, IOrderingTool
    {
        double foreignDeliveryDuration = 2d;
        double localDeliveryDuration = 0.5d;

        public Order OrderCard(CreditCard card)
        {
            Order cardOrder = new Order("Master revo card",
                DateTime.Now.AddDays(foreignDeliveryDuration).ToString(),
                100f);

            return CarryOutOrder(cardOrder, card);
        }

        public Order OrderItem(string name, float price, string originCountry, CreditCard card)
        {
            float transferCost = 0;
            double deliveryDuration = localDeliveryDuration;
            if (card.account.iban.StartsWith(originCountry))
            {
                transferCost = 0.02f * price;
                deliveryDuration = foreignDeliveryDuration;
            }
            string deliveryArrival = DateTime.Now.AddDays(deliveryDuration).ToString();

            Order order = new Order(name, deliveryArrival, price, transferCost);
            return CarryOutOrder(order, card);
        }
    }
}

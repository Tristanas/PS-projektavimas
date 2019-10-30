using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class RegularOrderingTool : IOrderingTool
    {
        // Duration in days.
        double foreignDeliveryDuration = 14;
        double localDeliveryDuration = 2;

        public Order OrderCard()
        {
            return new Order("Regular revo card", 
                DateTime.Now.AddDays(foreignDeliveryDuration).ToString(),
                0f);
        }

        public Order OrderItem(string name, float price, string originCountry, CreditCard card)
        {
            float transferCost = 0.01f * price;
            double deliveryDuration = localDeliveryDuration;
            if (card.account.iban.StartsWith(originCountry))
            {
                transferCost = 0.05f * price;
                deliveryDuration = foreignDeliveryDuration;
            }
            string deliveryArrival = DateTime.Now.AddDays(deliveryDuration).ToString();

            return new Order(name, deliveryArrival, price, transferCost);
        }
    }
}

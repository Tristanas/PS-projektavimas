using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class PremiumOrderingTool : IOrderingTool
    {
        // Duration in days.
        double foreignDeliveryDuration = 2d;
        double localDeliveryDuration = 0.5d;

        public Order OrderCard()
        {
            return new Order("Premium revo card",
                DateTime.Now.AddDays(foreignDeliveryDuration).ToString(),
                30f);
        }

        public Order OrderItem(string name, float price, string originCountry, CreditCard card)
        {
            float transferCost = 0.03f * price;
            double deliveryDuration = localDeliveryDuration;
            if (card.account.iban.StartsWith(originCountry))
            {
                transferCost = 0.10f * price;
                deliveryDuration = foreignDeliveryDuration;
            }
            string deliveryArrival = DateTime.Now.AddDays(deliveryDuration).ToString();

            return new Order(name, deliveryArrival, price, transferCost);
        }
    }
}

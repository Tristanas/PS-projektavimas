using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public class OrderingTool
    {
        ICollection<Order> orders;

        public OrderingTool()
        {
            orders = new List<Order>();
        }

        protected bool PayForOrder(Order order, CreditCard card)
        {
            return card.account.withraw(order.price + order.transferPrice);
        }

        protected Order CarryOutOrder(Order order, CreditCard card)
        {
            if (PayForOrder(order, card))
            {
                orders.Add(order);
                return order;
            }
            return null;
        }
    }
}

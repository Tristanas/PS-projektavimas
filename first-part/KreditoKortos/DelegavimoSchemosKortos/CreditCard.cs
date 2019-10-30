using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public class CreditCard
    {
        public float currentDayExpenses;
        public Account account;
        public ICollection<Order> orders;

        public CreditCard(Account account)
        {
            this.account = account;
            currentDayExpenses = 0;
            orders = new List<Order>();
        }

    }
}

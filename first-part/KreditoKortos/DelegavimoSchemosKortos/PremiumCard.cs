using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class PremiumCard : CreditCard
    {
        IPaymentTool paymentTool;
        ILoanManagementTool loanTool;
        IOrderingTool orderingTool;

        public PremiumCard(Account account, IPaymentTool payment, ILoanManagementTool loan,
            IOrderingTool ordering) : base(account)
        {
            paymentTool = payment;
            loanTool = loan;
            orderingTool = ordering;
        }

        public void GetLoan(CreditCard card, float sum)
        {
            loanTool.GetLoan(card, sum);
        }

        public Order OrderCard()
        {
            Order cardOrder = orderingTool.OrderCard();
            if (account.withraw(cardOrder.price))
            {
                orders.Add(cardOrder);
                return cardOrder;
            }
            return null;
        }

        public Order OrderItem(string name, float price, string originCountry, CreditCard creditCard)
        {
            Order newOrder = orderingTool.OrderItem(name, price, originCountry, creditCard);
            if (account.withraw(newOrder.price + newOrder.transferPrice))
            {
                orders.Add(newOrder);
                return newOrder;
            }
            return null;
        }

        public bool Transfer(float sum, Account recipient, CreditCard card)
        {
            return paymentTool.Transfer(sum, recipient, card);
        }

        public bool Withdraw(float sum, Currency currency, string atmCountry, CreditCard card)
        {
            return paymentTool.Withdraw(sum, currency, atmCountry, card);
        }
    }
}

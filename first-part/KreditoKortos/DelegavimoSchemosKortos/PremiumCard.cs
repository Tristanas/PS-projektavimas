using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class PremiumCard : CreditCard, IPaymentTool, ILoanManagementTool, IOrderingTool
    {
        IPaymentTool paymentTool;
        ILoanManagementTool loanTool;
        IOrderingTool orderingTool;

        public PremiumCard(Account account, IOrderingTool ordering = null,
            IPaymentTool payment = null,
            ILoanManagementTool loan = null) : base(account)
        {
            paymentTool = (payment != null) ? payment : new PremiumPaymentTool();
            loanTool = (loan != null) ? loan : new LoanDepositlessTool();
            orderingTool = (ordering != null) ? ordering : new PremiumOrderingTool();
        }

        public void GetLoan(float sum, CreditCard card = null)
        {
            loanTool.GetLoan(sum, this);
        }

        public Order OrderCard(CreditCard card = null)
        {
            return orderingTool.OrderCard(this);
        }

        public Order OrderItem(string name, float price, string originCountry, CreditCard creditCard = null)
        {
            return orderingTool.OrderItem(name, price, originCountry, this);
        }

        public bool Transfer(float sum, Account recipient, CreditCard card = null)
        {
            return paymentTool.Transfer(sum, recipient, this);
        }

        public bool Withdraw(float sum, Currency currency, string atmCountry, CreditCard card = null)
        {
            return paymentTool.Withdraw(sum, currency, atmCountry, this);
        }
    }
}

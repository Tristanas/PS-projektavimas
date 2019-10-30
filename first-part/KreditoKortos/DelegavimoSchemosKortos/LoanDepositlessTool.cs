using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class LoanDepositlessTool : ILoanManagementTool
    {
        float minimumLoan;
        float maximumLoan;

        public LoanDepositlessTool(float minLoan = 100f, float maxLoan = 5000f)
        {
            this.minimumLoan = minLoan;
            this.maximumLoan = maxLoan;
        }

        public void GetLoan(CreditCard card, float sum)
        {
            if (sum >= minimumLoan && sum <= maximumLoan)
            {
                Loan newLoan = new Loan(sum);
                if (card.account.setDebt(newLoan))
                {
                    card.account.deposit(newLoan.sum);
                    return;
                }
                Console.WriteLine("Unable to get a new loan, already in debt.");
                return;
            }
            Console.WriteLine("Invalid loan sum or deposit.");
        }
    }
}

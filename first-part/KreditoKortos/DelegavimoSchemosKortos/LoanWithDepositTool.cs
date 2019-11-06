using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    class LoanWithDepositTool : ILoanManagementTool
    {
        float minimumLoan;
        float maximumLoan;

        public LoanWithDepositTool(float minLoan = 100f, float maxLoan = 20000f)
        {
            this.minimumLoan = minLoan;
            this.maximumLoan = maxLoan;
        }

        public void GetLoan(float sum, CreditCard card)
        {
            if (sum >= minimumLoan && sum <= maximumLoan)
            {
                Console.WriteLine("You are required to make a deposit for the loan. Enter what property you deposit:");
                string deposit = Console.ReadLine();
                Loan newLoan = new Loan(sum, deposit);

                if (deposit == "car" || deposit == "house")
                {
                    if (card.account.setDebt(newLoan))
                    {
                        card.account.deposit(newLoan.sum);
                        return;
                    }
                    Console.WriteLine("Unable to get a new loan, already in debt.");
                    return;
                }
            }
            Console.WriteLine("Invalid loan sum or deposit.");
        }
    }
}

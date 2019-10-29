using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class LoanWithDeposit
    {
        float minLoan;
        float maxLoan;
        public LoanWithDeposit(float minLoan, float maxLoan)
        {
            this.minLoan = minLoan;
            this.maxLoan = maxLoan;
        }
        public string GetLoanDeposit()
        {
            Console.WriteLine("You are required to make a deposit for the loan. Enter what property you deposit:");
            return Console.ReadLine();
        }

        public bool IsLoanDepositSuitable(string deposit)
        {
            return deposit == "car" || deposit == "house";
        }

        public bool IsLoanPriceValid(float sum)
        {
            return sum > minLoan && sum < maxLoan;
        }
    }
}

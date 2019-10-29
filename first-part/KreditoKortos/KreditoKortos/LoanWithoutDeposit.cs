using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    class LoanWithoutDeposit
    {
        float minLoan;
        float maxLoan;
        public LoanWithoutDeposit(float minLoan, float maxLoan)
        {
            this.minLoan = minLoan;
            this.maxLoan = maxLoan;
        }

        public string GetLoanDeposit()
        {
            return "";
        }

        public bool IsLoanDepositSuitable(string deposit)
        {
            return true;
        }

        public bool IsLoanPriceValid(float sum)
        {
            return sum > minLoan && sum < maxLoan;
        }
    }
}

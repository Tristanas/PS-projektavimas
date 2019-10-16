using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardStrategy
{
    public interface ILoanStrategy
    {
        void GetLoan(CreditCard card, float sum);
    }
}

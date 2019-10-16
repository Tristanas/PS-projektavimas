using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class Loan
    {
        public float sum;
        // Some item.
        public string deposit;

        public Loan(float sum, string deposit = "")
        {
            this.sum = sum;
            this.deposit = deposit;
        }
    }
}

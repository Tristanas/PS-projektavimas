using KreditoKortos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegavimoSchemosKortos
{
    public interface ILoanManagementTool
    {
        void GetLoan(float sum, CreditCard card);
    }
}

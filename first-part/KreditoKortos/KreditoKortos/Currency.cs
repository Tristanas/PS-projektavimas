using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditoKortos
{
    public class Currency
    {
        public string Name;
        public float ValueInEuro;

        /// <summary>
        /// Transfers a sum of first currency to the second currency.
        /// </summary>
        /// <returns>The resulting sum of second currency.</returns>
        static public float ConvertCurrency(float sum, Currency firstCurrency, Currency resultCurrency)
        {
            float transferRatio = firstCurrency.ValueInEuro / resultCurrency.ValueInEuro;
            return sum * transferRatio;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public class FlatRateTax : TaxRateCalculatorBase
    {
        public override decimal Calculate(decimal incomeValue)
        {
            if (incomeValue < 0)
                return 0;

            return Percentage(incomeValue, 17.5m);
        }
    }
}

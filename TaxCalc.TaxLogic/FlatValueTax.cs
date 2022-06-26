using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public class FlatValueTax: TaxRateCalculatorBase
    {
        public override decimal Calculate(decimal incomeValue)
        {
            if (incomeValue < 0)
                return 0;

            if (incomeValue < 200000)
                return Percentage(incomeValue, 5);

            return 10000;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic.Enums;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public static class CalculatorFactory
    {
        public static ITaxRateCalculator CreateCalculator(TaxType taxType)
        {
            switch (taxType)
            {
                case TaxType.FlatValue:
                    return new FlatValueTax();
                case TaxType.FlatRate:
                    return new FlatRateTax();
                case TaxType.Progressive:
                    return new ProgressiveTax();
            }

            throw new ArgumentOutOfRangeException(taxType.ToString());
        }
    }
}

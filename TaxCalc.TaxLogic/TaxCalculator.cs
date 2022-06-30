using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic.Enums;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public static class TaxCalculator
    {
        public static decimal CalculateTax(TaxType taxType, int income)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(taxType);
            return taxCalculator.Calculate(income);            
        }
    }
}

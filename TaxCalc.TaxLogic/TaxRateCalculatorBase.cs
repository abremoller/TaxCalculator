using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public abstract class TaxRateCalculatorBase : ITaxRateCalculator
    {
        public abstract decimal Calculate(decimal income);

        public decimal Percentage(decimal value, decimal percentage)
        {
            return value * percentage / 100; 
        }
    }
}

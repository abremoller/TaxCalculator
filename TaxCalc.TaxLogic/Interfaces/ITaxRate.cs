using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalc.TaxLogic.Interfaces
{
    internal interface ITaxRate
    {
        //ITaxRateCalculator _taxRateCalculator;
        public decimal Calculate(decimal incomeValue, ITaxRateCalculator calculator);
    }
}

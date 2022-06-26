using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalc.TaxLogic.Interfaces
{
    public interface ITaxRateCalculator
    {
        decimal Calculate(decimal income);
    }
}

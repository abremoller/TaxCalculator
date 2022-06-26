using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic;

namespace TaxCalc.Test
{
    public class BasicTests: TaxRateCalculatorBase
    {
        public override decimal Calculate(decimal income)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TaxRateCalculatorBase_Percentage()
        {
            Assert.That(this.Percentage(100, 5) == 5);
        }
    }
}

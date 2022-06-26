using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.Test
{
    public class FlatValueCalculatorTests
    {
        [Test, Sequential]
        public void CalculateFlatValue_Expect_AccurateValue(
            [Values(10, 100000, 0, -10, 400000)] int income,
            [Values(0.5, 5000, 0, 0, 10000)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.FlatValue);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }
    }
}

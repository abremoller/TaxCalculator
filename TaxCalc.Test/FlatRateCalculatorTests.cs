using TaxCalc.TaxLogic;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.Test
{
    public class FlatRateCalculatorTests
    {
        [Test, Sequential]
        public void CalculateFlatRate_Expect_AccurateValue(
            [Values(10, 100000, 0, -10)] int income,
            [Values(1.75, 17500, 0, 0)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.FlatRate);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }
    }
}
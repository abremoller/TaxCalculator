using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic;
using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.Test
{
    public class ProgressiveCalculatorTests
    {
        [Test, Sequential]
        public void CalculateProgressiveTax_FirstTier_ExpectAccurate(
            [Values(10, 8350)] int income,
            [Values(1, 835)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }

        [Test, Sequential]
        public void CalculateProgressiveTax_SecondTier_ExpectAccurate(
            [Values(8351 + 100, 33950)] int income,
            [Values(835 + 15, 4674.85)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }

        [Test, Sequential]
        public void CalculateProgressiveTax_ThirdTier_ExpectAccurate(
            [Values(33951 + 100, 82250)] int income,
            [Values(4674.85 + 25, 16749.6)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }

        [Test, Sequential]
        public void CalculateProgressiveTax_ForthTier_ExpectAccurate(
            [Values(82251 + 100, 171550)] int income,
            [Values(16749.6 + 28, 41753.32)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }

        [Test, Sequential]
        public void CalculateProgressiveTax_FifthTier_ExpectAccurate(
            [Values(171551 + 100, 372950)] int income,
            [Values(41753.32 + 33, 108214.99)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }

        [Test, Sequential]
        public void CalculateProgressiveTax_SixthTier_ExpectAccurate(
            [Values(372951 + 100, 372950)] int income,
            [Values(108214.99 + 35, 108214.99)] decimal taxPayable)
        {
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(TaxLogic.Enums.TaxType.Progressive);
            var tax = taxCalculator.Calculate(income);

            Assert.That(tax, Is.EqualTo(taxPayable));
        }
    }
}

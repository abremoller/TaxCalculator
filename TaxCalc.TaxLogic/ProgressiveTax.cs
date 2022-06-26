using TaxCalc.TaxLogic.Interfaces;

namespace TaxCalc.TaxLogic
{
    public class ProgressiveTax: TaxRateCalculatorBase
    {
        List<(int fromIncome, uint toIncome, int rate, decimal preCalc)> taxRates = new List<(int, uint, int, decimal)>();

        public ProgressiveTax()
        {
            PopulateTaxRates();
        }

        public override decimal Calculate(decimal income)
        {
            if (income < 1)
                return 0;

            var rate = taxRates.First(x => income >= x.fromIncome && income <= x.toIncome);

            return Percentage(income - rate.fromIncome, rate.rate) + rate.preCalc;
        }

        private void PopulateTaxRates()
        {
            //TODO Move to DB as lookup
            taxRates.Add(new(0, 8350, 10, 0));
            taxRates.Add(new(8351, 33950, 15, 835));
            taxRates.Add(new(33951, 82250, 25, 4674.85m));
            taxRates.Add(new(82251, 171550, 28, 16749.6m));
            taxRates.Add(new(171551, 372950, 33, 41753.32m));
            taxRates.Add(new(372951, uint.MaxValue, 35, 108214.99m));
        }
    }
}
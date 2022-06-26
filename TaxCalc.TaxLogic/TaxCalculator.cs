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
        public static decimal CalculateTax(string postalCode, int income)
        {
            TaxType taxType = ResolveTaxTypeFromPostalCodeLookup(postalCode);
            ITaxRateCalculator taxCalculator = CalculatorFactory.CreateCalculator(taxType);
            return taxCalculator.Calculate(income);            
        }

        private static TaxType ResolveTaxTypeFromPostalCodeLookup(string postalCode)
        {
            //TODO Move to lookup DB
            switch (postalCode)
            {
                case "7441":
                    return TaxType.Progressive;
                case "A100":
                    return TaxType.FlatValue;
                case "7000":
                    return TaxType.FlatRate;
                case "1000":
                    return TaxType.Progressive;
                default:
                    throw new ArgumentException($"{postalCode} not mapped");
            }
        }
    }
}

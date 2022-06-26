using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalc.TaxLogic;

namespace TaxCalc.Test
{
    public class Scratchpad
    {
        enum TaxType
        {
            FlatValue,
            FlatRate,
            Progressive
        }

        public decimal CalculateTax(string postalCode, int income)
        {
            TaxType taxType;
            decimal taxPayableOnIncome = 0;

            //Move to DB
            switch(postalCode)
            {
                case "7441": 
                    taxType = TaxType.Progressive;
                    break;
                case "A100":
                    taxType = TaxType.FlatValue;
                    break;
                case "7000":
                    taxType = TaxType.FlatRate;
                    break;
                case "1000":
                    taxType = TaxType.Progressive;
                    break;
                default: 
                    throw new ArgumentException($"{postalCode} not mapped");
            }

            //Make generic
            switch(taxType)
            {
                case TaxType.FlatValue:
                    taxPayableOnIncome = new FlatValueTax().Calculate(income);
                    break;
                case TaxType.FlatRate:
                    taxPayableOnIncome = new FlatRateTax().Calculate(income);
                    break;
                case TaxType.Progressive:
                    taxPayableOnIncome = new ProgressiveTax().Calculate(income);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("TaxType");
            }

            SaveRecordToDB(postalCode, income);

            return taxPayableOnIncome;
        }

        private void SaveRecordToDB(string postalCode, int income)
        {
            //Save To DB
        }
    }
}

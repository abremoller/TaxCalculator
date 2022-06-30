using System.ComponentModel.DataAnnotations;
using TaxCalc.TaxLogic.Enums;

namespace TaxCalc.API.Data
{
    public class PostalCodes
    {
        [Key]
        public string Code { get; set; }
        public TaxType TaxType { get; set; }
    }
}

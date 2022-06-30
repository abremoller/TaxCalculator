using System.ComponentModel.DataAnnotations;

namespace TaxCalc.Web.Models
{
    public class TaxCalculationDataModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? PostalCode { get; set; }
        public int Income { get; set; }
    }
}

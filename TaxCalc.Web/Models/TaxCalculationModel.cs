namespace TaxCalc.Web.Models
{
    public class TaxCalculationModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? PostalCode { get; set; }
        public int Income { get; set; }
        public decimal TaxPayable { get; set; }
        public bool IsPostBack { get; set; } = false;
    }
}

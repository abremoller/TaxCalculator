using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalc.Web.Models;

namespace TaxCalc.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _http;
        private readonly TaxCalcDbContext _dataContext;

        [BindProperty]
        public TaxCalculationModel TaxCalculationModel { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HttpClient http, TaxCalcDbContext dataContext)
        {
            _logger = logger;
            _http = http;
            _dataContext = dataContext;
        }

        public void OnGet()
        {

        }

        public IEnumerable<string> GetPostalCodes()
        {
            return _http.GetFromJsonAsync<IEnumerable<string>>($"TaxCalc/GetPostalCodes").Result ?? new List<string>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //TODO Add error message to UI
            if (String.IsNullOrEmpty(TaxCalculationModel.PostalCode))
                return Page();

            try
            {
                LogToDb();

                CallTaxPayableService();
            }
            catch(Exception ex)
            {
                TaxCalculationModel.IsPostBack = false;

                if (_logger != null)
                    _logger.Log(LogLevel.Error, ex, "Error getting tax payable");
            }

            return Page();
        }

        private void CallTaxPayableService()
        {
            decimal taxPayable = _http.GetFromJsonAsync<decimal>($"TaxCalc/GetPersonalTaxPayable?postalCode={TaxCalculationModel.PostalCode}&income={TaxCalculationModel.Income}").Result;
            TaxCalculationModel.TaxPayable = taxPayable;
            TaxCalculationModel.IsPostBack = true;
        }

        private void LogToDb()
        {
            TaxCalculationDataModel dataModel = new TaxCalculationDataModel() { DateTime = DateTime.Now, Income = TaxCalculationModel.Income, PostalCode = TaxCalculationModel.PostalCode };
            _dataContext.Add(dataModel);
            _dataContext.SaveChanges();
        }
    }
}   
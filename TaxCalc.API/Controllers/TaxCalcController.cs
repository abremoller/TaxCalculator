using Microsoft.AspNetCore.Mvc;
using TaxCalc.API.Data;
using TaxCalc.TaxLogic;

namespace TaxCalc.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TaxCalcController : Controller
    {
        private readonly TaxCalcDbContext _dataContext;
        private readonly IEnumerable<PostalCodes> _postalCodes;


        public TaxCalcController(TaxCalcDbContext dataContext)
        {
            _dataContext = dataContext;
            _postalCodes = dataContext.PostalCodes;
        }
        

        [HttpGet(Name = "GetPostalCodes")]
        public IEnumerable<string> GetPostalCodes() => _postalCodes.Select(x => x.Code);

        [HttpGet(Name = "GetPersonalTaxPayable")]
        public decimal GetPersonalTaxPayable(string postalCode, int income)
        {
            var code = _postalCodes.FirstOrDefault(x => x.Code == postalCode);

            if (code == null) return 0;

            return TaxCalculator.CalculateTax(code.TaxType, income);
        }
    }
}

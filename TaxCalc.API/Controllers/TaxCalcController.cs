using Microsoft.AspNetCore.Mvc;
using TaxCalc.TaxLogic;

namespace TaxCalc.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TaxCalcController : Controller
    {
        //TODO: Remove, move to DB
        private static readonly string[] _postalCodes = new[]
        {
            "7441", "A100", "7000", "1000"
        };

        [HttpGet(Name = "GetPostalCodes")]
        public IEnumerable<string> GetPostalCodes() => _postalCodes;

        [HttpGet(Name = "GetPersonalTaxPayable")]
        public decimal GetPersonalTaxPayable(string postalCode, int income) => TaxCalculator.CalculateTax(postalCode, income);
    }
}

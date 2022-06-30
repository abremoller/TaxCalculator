using Microsoft.EntityFrameworkCore;
using TaxCalc.Web.Models;

namespace TaxCalc.Web
{

    public class TaxCalcDbContext : DbContext
    {
        public TaxCalcDbContext(DbContextOptions<TaxCalcDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaxCalculationDataModel> TaxCalculation => Set<TaxCalculationDataModel>();
    }
}

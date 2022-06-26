using Microsoft.EntityFrameworkCore;

namespace TaxCalc.API
{

    public class TaxCalcDbContext : DbContext
    {
        public TaxCalcDbContext(DbContextOptions<TaxCalcDbContext> options)
            : base(options)
        {
        }

        
    }
}

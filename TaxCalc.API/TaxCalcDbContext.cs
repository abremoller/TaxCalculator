using Microsoft.EntityFrameworkCore;
using TaxCalc.API.Data;

namespace TaxCalc.API
{

    public class TaxCalcDbContext : DbContext
    {
        public TaxCalcDbContext(DbContextOptions<TaxCalcDbContext> options)
            : base(options)
        {
        }

        public DbSet<PostalCodes> PostalCodes => Set<PostalCodes>();
    }
}

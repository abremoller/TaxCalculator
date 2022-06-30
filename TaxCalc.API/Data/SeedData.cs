using Microsoft.EntityFrameworkCore;

namespace TaxCalc.API.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TaxCalcDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TaxCalcDbContext>>()))
            {

                // Look for any postal code.
                if (context.PostalCodes.Any())
                {
                    return;   // DB has been seeded
                }


                context.Add(
                    new PostalCodes()
                    {
                        Code = "7441",
                        TaxType = TaxLogic.Enums.TaxType.Progressive
                    });

                context.Add(
                    new PostalCodes()
                    {
                        Code = "A100",
                        TaxType = TaxLogic.Enums.TaxType.FlatValue
                    });

                context.Add(
                    new PostalCodes()
                    {
                        Code = "7000",
                        TaxType = TaxLogic.Enums.TaxType.FlatRate
                    });

                context.Add(
                    new PostalCodes()
                    {
                        Code = "1000",
                        TaxType = TaxLogic.Enums.TaxType.Progressive
                    });

                context.SaveChanges();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PRN232.Lab2.CoffeeStore.Data.Data;

namespace PRN232.Lab2.CoffeeStore.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql("Host=aws-1-us-east-2.pooler.supabase.com; Database=postgres; Username=postgres.xfxenptbplflzryxxnsu; Password=Abcd12345@");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

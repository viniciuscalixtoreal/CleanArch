using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CleanArch.Infrastructure.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // change if needed
            optionsBuilder.UseSqlServer("server=DESK-VINICIUS; database=DataBase; trusted_connection=true; trustservercertificate=true");

            return new ApplicationDbContext(optionsBuilder.Options);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SVE.Persistence.Context;

namespace SVE.Persistence
{
    public class SVEContextFactory : IDesignTimeDbContextFactory<SVEContext>
    {
        public SVEContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SVEContext>();

            var connectionString = "Server=localhost;Database= sve_db;User=root;Password=Mariely.03;";

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new SVEContext(optionsBuilder.Options);
        }
    }
}


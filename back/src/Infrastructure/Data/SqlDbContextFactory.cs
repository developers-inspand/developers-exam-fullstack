using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class SqlDbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
    {
        public SqlDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=INSPAND_Exam;User Id=sa;Password=5Gi3re61sXehuSGxMqHX;TrustServerCertificate=True;").LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);

            return new SqlDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        // Example table
        public DbSet<Employee> Employees { get; set; }
    }
}

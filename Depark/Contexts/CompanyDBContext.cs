using Depark.Models;
using Microsoft.EntityFrameworkCore;

namespace Depark.Contexts
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=companies.db");
        }
    }
}
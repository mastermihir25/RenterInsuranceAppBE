using Microsoft.EntityFrameworkCore;
using RenterInsuranceApp.Models;

namespace RenterInsuranceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Item> Items { get; set; }
    }
}

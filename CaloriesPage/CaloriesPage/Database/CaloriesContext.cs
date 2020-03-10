using CaloriesPage.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaloriesPage.Database
{
    public class CaloriesContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }

        public CaloriesContext(DbContextOptions options) : base(options)
        {

        }
    }
}

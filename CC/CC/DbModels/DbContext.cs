using Microsoft.EntityFrameworkCore;

namespace CC.DbModels
{
    public class CCDbContext : DbContext
    {
        public CCDbContext(DbContextOptions<CCDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<FoodItemConsumed> FoodItemConsumed { get;set;}
        public DbSet<User> User { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace CC.DbModels
{
    public class CCDbContext : DbContext
    {
        public CCDbContext(DbContextOptions<CCDbContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<FoodItemConsumed> FoodItemConsumed { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ActivityLevel> ActivityLevel {get;set;}
        public DbSet<Goal> Goal { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<PrefferedDiet> PrefferedDiet { get; set; }
    }
}

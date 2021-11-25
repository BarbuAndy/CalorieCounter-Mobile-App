using CC.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Helpers
{
    public class DataSeeder
    {
        private readonly CCDbContext context;

        public DataSeeder(CCDbContext serviceScope)
        {
            this.context = serviceScope;
        }

        public void Seed()
        {
            this.SeedGoals();
            this.SeedActivityLevels();
            this.SeedPrefferedDiet();
        }

        public void SeedGoals()
        {
            context.Goal.RemoveRange(context.Goal);
            context.Goal.Add(new Goal { goalId = 1, description = "Lose weight" });
            context.Goal.Add(new Goal { goalId = 2, description = "Gain weight" });
            context.Goal.Add(new Goal { goalId = 3, description = "Maintain" });
            context.SaveChanges();
        }

        public void SeedActivityLevels()
        {
            context.ActivityLevel.RemoveRange(context.ActivityLevel);
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 1, description = "Sedentary" });
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 2, description = "Light exercise" });
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 3, description = "Moderate exercise" });
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 4, description = "Daily light exercise" });
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 5, description = "Daily moderate exercise" });
            context.ActivityLevel.Add(new ActivityLevel { activityLevelId = 6, description = "Very active daily" });
            context.SaveChanges();
        }

        public void SeedPrefferedDiet()
        {
            context.PrefferedDiet.RemoveRange(context.PrefferedDiet);
            context.PrefferedDiet.Add(new PrefferedDiet {
                prefferedDietId = 1,
                description = "Balanced",
                carbohydratePercentage = 50,
                fatsPercentage = 25,
                proteinPercentage = 25
                });

            context.PrefferedDiet.Add(new PrefferedDiet
            {
                prefferedDietId = 2,
                description = "High protein",
                carbohydratePercentage = 30,
                fatsPercentage = 35,
                proteinPercentage = 35
                });

            context.PrefferedDiet.Add(new PrefferedDiet
            {
                prefferedDietId = 3,
                description = "High fat",
                carbohydratePercentage = 35,
                fatsPercentage = 40,
                proteinPercentage = 25
                });

            context.PrefferedDiet.Add(new PrefferedDiet
            {
                prefferedDietId = 4,
                description = "Keto diet",
                carbohydratePercentage = 5,
                fatsPercentage = 70,
                proteinPercentage = 25
            });
            context.SaveChanges();
        }

    }
}

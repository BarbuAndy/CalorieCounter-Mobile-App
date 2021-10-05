using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class Statistics
    {
        public Statistics()
        {
            this.meals = new List<Meal>();
        }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public List<Meal> meals { get; set; }
        public float totalCalories {get;set;}
        public float totalProtein {get;set;}
        public float totalCarbohydrate { get; set; }
        public float totalFat { get; set; }


        public void ComputeTotals()
        {
            this.meals.ForEach(m =>
            {
                this.totalCalories += m.calories;
                this.totalProtein += m.protein;
                this.totalCarbohydrate += m.carbohydrates;
                this.totalFat += m.fats;

            });
        }
        public bool ContainsMeal(string meal)
        {
            return meals.Any(m => m.name == meal);
        }

    }
}

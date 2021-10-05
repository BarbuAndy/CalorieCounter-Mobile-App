using CC.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class Meal
    {
        public Meal()
        {
            this.carbohydrates = 0;
            this.calories = 0;
            this.protein = 0;
            this.fats = 0;
        }
        public string name { get; set; }
        public float calories { get; set; }
        public float protein { get; set; }
        public float carbohydrates { get; set; }
        public float fats { get; set; }

        public void AddFoodItem(FoodItemConsumed i)
        {
            this.calories += i.foodItem.calories * i.quantity / 100;
            this.protein += i.foodItem.protein * i.quantity / 100;
            this.carbohydrates += i.foodItem.carbohydrates * i.quantity / 100;
            this.fats += i.foodItem.fats * i.quantity / 100;
        }
    }
}

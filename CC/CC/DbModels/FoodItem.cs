using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class FoodItem
    {
        [Key]
        public int foodItemId { get; set; }
        public string name { get; set; }
        public int calories { get; set; }
        public float protein { get; set; }
        public float carbohydrates { get; set; }
        public float fats { get; set; }
        public string note { get; set; }
        public string code { get; set; }
        public int timesFlaggedWrong { get; set; }
        public bool published { get; set; }
    }
}

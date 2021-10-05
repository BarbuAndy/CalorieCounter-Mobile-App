using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class FoodItemConsumed
    {
        [Key]
        public int foodItemConsumedId { get; set; }
        public int foodItemId { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; } //in grams
        public DateTime dateTime { get; set; }
        public string meal { get; set; }

        public virtual FoodItem foodItem { get; set; }
        public virtual User user { get; set; }
    }
}

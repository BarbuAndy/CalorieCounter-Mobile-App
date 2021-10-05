using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Queries
{
    public class FoodItemConsumedQuery
    {
        public FoodItemConsumedQuery()
        {
            this.includeFood = false;
            this.includeUser = false;
        }

        public int foodItemConsumedId { get; set; }
        public int foodId { get; set; }
        public int userId { get; set; }
        public DateTime dateTimeMin { get; set; }
        public DateTime dateTimeMax { get; set; }
        public string meal { get; set; }
        public bool includeFood { get; set; }
        public bool includeUser { get; set; }
    }
}

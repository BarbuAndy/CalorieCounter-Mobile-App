using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Queries
{
    public class FoodItemQuery
    {
        public int foodItemId { get; set; }
        public string name { get; set; }
        public int proteinMin { get; set; }
        public int proteinMax { get; set; }
        public int carbohydratesMin { get; set; }
        public int carbohydratesMax { get; set; }
        public int fatsMin { get; set; }
        public int fatsMax { get; set; }
        public bool? published { get; set; }
        public int timesFlaggedWrongMin {get;set;}
        public int timesFlaggedWrongMax { get; set; }
        public int numberOfResults { get; set; }
    }
}

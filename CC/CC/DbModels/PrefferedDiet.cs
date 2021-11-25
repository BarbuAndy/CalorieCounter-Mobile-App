using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class PrefferedDiet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int prefferedDietId { get; set; }
        public string description { get; set; }
        public int carbohydratePercentage { get; set; }
        public int fatsPercentage { get; set; }
        public int proteinPercentage { get; set; }
    }
}

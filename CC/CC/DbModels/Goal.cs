using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int goalId { get; set; }
        public string description { get; set; }
    }
}

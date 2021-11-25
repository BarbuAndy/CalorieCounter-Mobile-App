using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class UserData
    {
        [Key]
        public int userDataId { get; set; }
        public int weight { get; set; }
        public int userId { get; set; }
        public int activityLevelId { get; set; }
        public int goalId { get; set; }
        public int prefferedDietId { get; set; }
        public DateTime dateSet { get; set; }
        public virtual ActivityLevel activityLevel {get;set;}
        public virtual Goal goal {get;set;}
        public virtual PrefferedDiet prefferedDiet { get; set; }
    }
}

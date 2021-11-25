using CC.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class GoalVariables
    {
        public List<ActivityLevel> activityLevels { get; set; }
        public List<Goal> goals { get; set; }
        public List<PrefferedDiet> prefferedDiets { get; set; }
    }
}

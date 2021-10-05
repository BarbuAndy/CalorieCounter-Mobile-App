using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Queries
{
    public class StatisticsQuery
    {
        public int userId { get; set; }
        public DateTime dateMin { get; set; }
        public DateTime dateMax { get; set; }
    }
}

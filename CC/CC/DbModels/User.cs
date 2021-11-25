using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CC.DbModels
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string token { get; set; }
        public virtual HashSet<UserData> userData { get; set; }
    }
}

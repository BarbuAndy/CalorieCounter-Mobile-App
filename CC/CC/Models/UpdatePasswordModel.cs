using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class UpdatePasswordModel
    {
        public int userId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}

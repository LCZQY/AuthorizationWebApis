using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Model
{
    public class TraceUpdateBase
    {
        [MaxLength(127)]
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }

        //[MaxLength(127)]
        //public string UpdateUser { get; set; }
        //public DateTime? UpdateTime { get; set; }

        [MaxLength(127)]
        public string DeleteUser { get; set; }
        public DateTime? DeleteTime { get; set; }

        //[NotMapped]
        //public SimpleUser CreateUserInfo { get; set; }

        //[NotMapped]
        //public SimpleUser UpdateUserInfo { get; set; }

        //[NotMapped]
        //public SimpleUser DeleteUserInfo { get; set; }

    }
}

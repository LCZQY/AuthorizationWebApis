using System;
using System.ComponentModel.DataAnnotations;

namespace AuthorityManagementCent.Model
{
    public class TraceUpdateBase
    {
        [MaxLength(127)]
        public string CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }

        [MaxLength(127)]
        public string DeleteUser { get; set; }
        public DateTime? DeleteTime { get; set; }



    }
}

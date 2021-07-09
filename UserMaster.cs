using System;
using System.Collections.Generic;

#nullable disable

namespace WindowService2
{
    public partial class UserMaster
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public DateTime UserRoles { get; set; }
        public string UserEmailId { get; set; }
    }
}

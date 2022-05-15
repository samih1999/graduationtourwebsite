using System.Collections.Generic;

namespace graduationtourwebsite.Models
{
    public class UserRoleviewmodel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public  List<Rolesview>  Roles { get; set; }
    }
}

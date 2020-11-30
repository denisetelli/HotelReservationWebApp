using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Type { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

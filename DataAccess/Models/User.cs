using System;

namespace DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }
               
        public string FirstName { get; set; }

        public string LastName { get; set; }
                
        public string Email { get; set; }
                             
        public string Password { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool IsDeleted { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }       
    }
}

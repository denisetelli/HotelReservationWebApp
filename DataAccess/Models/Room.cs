using System;

namespace DataAccess.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string Code { get; set; }  

        public int MaxOfGuests { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

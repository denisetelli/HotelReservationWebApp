using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}

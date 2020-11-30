using Commom.Enums;
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int? ContactPersonId { get; set; }

        public int MainGuestId { get; set; }

        public int RoomCategoryId { get; set; }

        public int RoomId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public double TotalAmount { get; set; }

        public ReservationStatusEnum Status { get; set; }

        public virtual ICollection<ReservationClient> ReservationClients { get; set; }

        public virtual Client ContactPerson { get; set; }

        public virtual Client MainGuest { get; set; }

        public virtual Category RoomCategory { get; set; }

        public virtual Room Room { get; set; }
    }
}

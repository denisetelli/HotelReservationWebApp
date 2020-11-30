using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTransilvania.ViewModels
{
    public class ArrivalsOfTheDayViewModel
    {
        public int ReservationId { get; set; }

        public string CreationDate { get; set; }

        public string Arrival { get; set; }

        public string Departure { get; set; }

        public string Status { get; set; }

        public string ContactPersonFullName { get; set; }

        public string MainGuestFullName { get; set; }

        public string RoomCategory { get; set; }

        public string RoomCode { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ReservationClient
    {
        public int ReservationId { get; set; }

        public  Reservation Reservation { get; set; }

        public   Client Client { get; set; }

        public int ClientId { get; set; }
    }
}

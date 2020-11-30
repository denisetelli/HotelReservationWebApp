using Commom.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commom.DTOs
{
    public class ReservationDTO
    {
        public ReservationDTO()
        {
            ReservationClients = new List<ReservationClientDTO>();
        }

        public int ReservationId { get; set; }

        public int? ContactPersonId { get; set; }
        
        public int MainGuestId { get; set; }

        public int RoomCategoryId { get; set; }

        public int RoomId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }

        public int TotalNights { get; set; }
                          
        public double Rate { get; set; }
        
        public double TotalAmount { get; set; }

        public int MaxOfGuests { get; set; }

        public ReservationStatusEnum Status { get; set; }

        public List<ReservationClientDTO> ReservationClients { get; set; }

        public string ContactPersonFullName { get; set; }

        public string MainGuestFullName { get; set; }

        public string RoomCategory { get; set; }

        public string RoomCode { get; set; }       
    }
}

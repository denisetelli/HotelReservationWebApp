using Commom.Enums;
using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Cnpj { get; set; }

        public string TradeName { get; set; }

        public ClientTypeEnum Type { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ReservationClient> ReservationClients { get; set; }
    }
}

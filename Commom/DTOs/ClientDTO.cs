using Commom.Enums;
using Commom.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commom.DTOs
{
    public class ClientDTO : IDocumentProvider
    {      
        public int ClientId { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
             ErrorMessage = "O e-mail não foi inserido da maneira correta.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data de nascimento é obrigatória.", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório.", AllowEmptyStrings = false)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Nome fantasia é obrigatório.", AllowEmptyStrings = false)]
        public string TradeName { get; set; }

        public ClientTypeEnum Type { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ReservationClientDTO> ReservationClients { get; set; }

        public string FullNamePersonOnly { get; set; } 

        public string FullName { get; set; }
    }
}

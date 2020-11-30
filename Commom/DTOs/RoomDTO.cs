using System;
using System.ComponentModel.DataAnnotations;

namespace Commom.DTOs
{
    public class RoomDTO
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Código é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(4, MinimumLength = 4)]
        [RegularExpression(@"^[A-Z]{1}[0-9]{1}[0-0]{1}[0-9]{1}$",
        ErrorMessage = "Formato inválido. O código deve conter uma letra maiúscula e três números. " +
            "Exemplos: A101, B202, C305.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.", AllowEmptyStrings = false)]
        [RegularExpression(@"^[1-5]$",
             ErrorMessage = "Quantidade inválida. Capacidade deve estar entre 1-5 hóspedes.")]
        public int MaxOfGuests { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Categoria é obrigatória.", AllowEmptyStrings = false)]
        public int CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

    }
}

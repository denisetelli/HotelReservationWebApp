using System;
using System.ComponentModel.DataAnnotations;

namespace Commom.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
            ErrorMessage = "O e-mail não foi inserido da maneira correta.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[\d])(?:.*[^a-zA-Z])",
            ErrorMessage = "A senha deve conter 6 caracteres incluindo letras e números.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmação de senha é obrigatória.", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[\d])(?:.*[^a-zA-Z])", ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmedPassword { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "Autorização é obrigatória.")]
        public int RoleId { get; set; }

        public RoleDTO Role { get; set; }        
    }
}

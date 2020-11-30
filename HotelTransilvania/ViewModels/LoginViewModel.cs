using System.ComponentModel.DataAnnotations;

namespace HotelTransilvania.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="E-mail necessário.", AllowEmptyStrings =false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha necessária.", AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Dto.User
{
    public class NuevaClaveRequestDTO
    {
        public string Token { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Required]
        public string PasswordConfirm { get; set; }

    }
}

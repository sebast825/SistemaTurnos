using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Dto.User
{
    public class RecoveryEmailRequestDo
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}

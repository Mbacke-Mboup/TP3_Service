using System.ComponentModel.DataAnnotations;

namespace FlappyAPI.Models
{
    public class RegisterDTO
    {
        [Required]
        public String Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public String Email { get; set; } = null!;
        [Required]
        public String Password { get; set; } = null!;
        [Required]
        public String PasswordConfirm { get; set; } = null!;
    }
}

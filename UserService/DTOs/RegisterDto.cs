using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class RegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // "Patient" or "Doctor" etc.

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}

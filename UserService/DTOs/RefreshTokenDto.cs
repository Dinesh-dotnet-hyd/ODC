using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}

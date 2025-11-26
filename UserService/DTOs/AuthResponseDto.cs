namespace UserService.DTOs
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
        public DateTime RefreshTokenExpiresAt { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

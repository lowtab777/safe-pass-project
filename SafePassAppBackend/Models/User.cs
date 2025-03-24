namespace SafePassAppBackend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Login { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
    }
}

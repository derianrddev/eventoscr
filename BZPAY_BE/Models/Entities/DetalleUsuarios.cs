namespace BZPAY_BE.Models.Entities
{
    public class DetalleUsuarios
    {
        public string Id { get; set; } = null!;

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? SecurityStamp { get; set; }

        public string? ConcurrencyStamp { get; set; }

        public string? PhoneNumber { get; set; }

        public string? RoleName { get; set; }
    }
}

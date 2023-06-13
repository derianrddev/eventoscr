namespace BZPAY_BE.Models
{
    public partial class UserRoles
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;

    }
}

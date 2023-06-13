namespace BZPAY_BE.DataAccess
{
    public class RoleDo
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? NormalizedName { get; set; }

        public string? ConcurrencyStamp { get; set; }
    }
}

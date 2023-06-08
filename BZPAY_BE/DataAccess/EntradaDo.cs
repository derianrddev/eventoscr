using BZPAY_BE.Models;

namespace BZPAY_BE.DataAccess
{
    public class EntradaDo
    {
        public int Id { get; set; }

        public int Disponibles { get; set; }

        public string TipoAsiento { get; set; } = null!;

        public decimal Precio { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime UpdatedAt { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public int IdEvento { get; set; }

    }
}

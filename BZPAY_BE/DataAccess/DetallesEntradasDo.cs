using System.ComponentModel;

namespace BZPAY_BE.DataAccess
{
    public class DetalleEntradaDo
    {
        public int Id { get; set; }

        public int Disponibles { get; set; }

        public string TipoAsiento { get; set; } = null!;

        public decimal Precio { get; set; }
    }
}

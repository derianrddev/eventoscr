using System.ComponentModel;

namespace BZPAY_BE.DataAccess
{
    public class ImprimirEntradaDo
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaReserva { get; set; }

        public DateTime FechaPago { get; set; }

        public string? TipoAsiento { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }

        public string? Evento { get; set; }

        public string? Escenario { get; set; }

        public string? IdCliente { get; set; }

        public string? UserName { get; set; }
    }
}

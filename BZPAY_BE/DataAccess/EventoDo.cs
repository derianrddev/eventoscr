using BZPAY_BE.Models;

namespace BZPAY_BE.DataAccess
{
    public class EventoDo
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime UpdatedAt { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public int IdTipoEvento { get; set; }

        public int IdEscenario { get; set; }

        public string DescripcionEscenario { get; set; }

        public string Escenario { get; set; }

        public string Localizacion { get; set; }

    }
}

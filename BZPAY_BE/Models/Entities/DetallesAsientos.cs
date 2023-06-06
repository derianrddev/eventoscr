using System.ComponentModel;

namespace BZPAY_BE.Models.Entities;

public class DetalleAsiento
{
    [DisplayName("Id del Asiento")]
    public int Id { get; set; }

    [DisplayName("Id del Evento")]
    public int IdEvento { get; set; }

    [DisplayName("Descripción")]
    public string TipoAsiento { get; set; } = null!;

    public int Cantidad { get; set; }
}


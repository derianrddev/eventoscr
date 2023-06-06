using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

public partial class Entrada
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

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Evento IdEventoNavigation { get; set; } = null!;
}

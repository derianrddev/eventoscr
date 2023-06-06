using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

public partial class Escenario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Localizacion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<TipoEscenario> TipoEscenarios { get; set; } = new List<TipoEscenario>();
}

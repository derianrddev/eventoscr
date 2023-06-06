﻿using System;
using System.Collections.Generic;

namespace BZPAY_BE.Models;

/// <summary>
/// tipos de asiento del escenario
/// </summary>
public partial class Asiento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public bool Active { get; set; }

    public int IdEscenario { get; set; }

    public virtual Escenario IdEscenarioNavigation { get; set; } = null!;
}

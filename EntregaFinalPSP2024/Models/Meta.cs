using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Meta
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaLimite { get; set; }

    public string? Estado { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

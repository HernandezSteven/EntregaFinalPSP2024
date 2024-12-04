using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Progreso
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEjercicio { get; set; }

    public string? Estado { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFinalizacion { get; set; }

    public virtual Ejercicio? IdEjercicioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

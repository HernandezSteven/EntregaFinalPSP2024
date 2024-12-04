using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Estadistica
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEjercicio { get; set; }

    public double? TiempoEmpleado { get; set; }

    public int? Intentos { get; set; }

    public string? Resultado { get; set; }

    public DateOnly? FechaRealizacion { get; set; }

    public virtual Ejercicio? IdEjercicioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

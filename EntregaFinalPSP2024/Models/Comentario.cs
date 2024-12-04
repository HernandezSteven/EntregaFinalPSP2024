using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEjercicio { get; set; }

    public string? Comentario1 { get; set; }

    public DateOnly? FechaComentario { get; set; }

    public virtual Ejercicio? IdEjercicioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}

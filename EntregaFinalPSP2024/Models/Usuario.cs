using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int? IdRol { get; set; }

    public string? Nivel { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Meta> Meta { get; set; } = new List<Meta>();

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}

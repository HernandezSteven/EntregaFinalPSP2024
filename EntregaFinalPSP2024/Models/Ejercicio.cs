using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Ejercicio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Dificultad { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Estadistica> Estadisticas { get; set; } = new List<Estadistica>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}

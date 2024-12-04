using System;
using System.Collections.Generic;

namespace EntregaFinalPSP2024.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();
}

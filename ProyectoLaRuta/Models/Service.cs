using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Service
{
    public long Id { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public long UserId { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual User User { get; set; } = null!;
}

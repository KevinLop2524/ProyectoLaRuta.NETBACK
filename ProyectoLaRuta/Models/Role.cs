using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Role
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}

using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class ComunidadUsuario
{
    public long Id { get; set; }

    public long ComunidadId { get; set; }

    public long UsuarioId { get; set; }

    public virtual Comunidad Comunidad { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}

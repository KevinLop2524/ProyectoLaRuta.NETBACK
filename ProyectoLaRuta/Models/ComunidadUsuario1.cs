using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class ComunidadUsuario1
{
    public long ComunidadesId { get; set; }

    public long UsuariosId { get; set; }

    public virtual Comunidad Comunidades { get; set; } = null!;

    public virtual Usuario Usuarios { get; set; } = null!;
}

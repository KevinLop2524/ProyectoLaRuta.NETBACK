using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Publicacion
{
    public long Id { get; set; }

    public string? Categoria { get; set; }

    public string? Contenido { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Nombre { get; set; }

    public long? UsuarioId { get; set; }
}

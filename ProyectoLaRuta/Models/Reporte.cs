using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Reporte
{
    public long Id { get; set; }

    public double? Cantidad { get; set; }

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public double? Precio { get; set; }

    public long? ComunidadId { get; set; }

    public long? UsuarioId { get; set; }

    public virtual Comunidad? Comunidad { get; set; }

    public virtual Usuario? Usuario { get; set; }
}

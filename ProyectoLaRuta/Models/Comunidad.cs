using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Comunidad
{
    public long Id { get; set; }

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public long? IdCreador { get; set; }

    public string? Nombre { get; set; }

    public string? Tematica { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<ComunidadUsuario> ComunidadUsuarios { get; set; } = new List<ComunidadUsuario>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}

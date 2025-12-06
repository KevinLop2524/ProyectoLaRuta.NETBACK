using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public double Altura { get; set; }

    public string? Apellido { get; set; }

    public string? Apellido2 { get; set; }

    public string? Apodo { get; set; }

    public string? Contrasena { get; set; }

    public string? Correo { get; set; }

    public string? Localidad { get; set; }

    public string? Nacimiento { get; set; }

    public string? Nombre { get; set; }

    public string? Nombre2 { get; set; }

    public string? Sexo { get; set; }

    public virtual ICollection<ComunidadUsuario> ComunidadUsuarios { get; set; } = new List<ComunidadUsuario>();

    public virtual ICollection<ImageFile> ImageFiles { get; set; } = new List<ImageFile>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}

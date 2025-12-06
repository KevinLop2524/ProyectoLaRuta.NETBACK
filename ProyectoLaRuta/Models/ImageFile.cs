using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class ImageFile
{
    public string Id { get; set; } = null!;

    public string? Categoria { get; set; }

    public string ContentType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? Estado { get; set; }

    public DateOnly? Fecha { get; set; }

    public string Filename { get; set; } = null!;

    public long Size { get; set; }

    public string? Tipo { get; set; }

    public long UserId { get; set; }

    public virtual Usuario User { get; set; } = null!;
}

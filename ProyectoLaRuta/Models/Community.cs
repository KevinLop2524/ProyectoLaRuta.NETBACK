using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProyectoLaRuta.Models;

public partial class Community
{
    public long Id { get; set; }

    public bool Active { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    public string Category { get; set; }
    public DateTime? DateOfCreation { get; set; }

    public DateTime? DeletedAt { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [StringLength(500, ErrorMessage = "La descripción debe tener máximo 500 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar 100 caracteres.")]
    public string Name { get; set; }

    public long CreatorId { get; set; }

    public bool AllowsPosts { get; set; }

    public string? PostRules { get; set; }

    public string? BannerPublicId { get; set; }

    public string? BannerUrl { get; set; }

    public string? LogoPublicId { get; set; }

    public string? LogoUrl { get; set; }

    public virtual ICollection<CommunityMembership> CommunityMemberships { get; set; } = new List<CommunityMembership>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

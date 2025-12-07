using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLaRuta.Models;

public partial class User
{
    public long Id { get; set; }

    public ulong Active { get; set; }

    [Display(Name = "Fecha de nacimiento")]

    public DateOnly? DateOfBirth { get; set; }

    public DateTime? DateOfCreation { get; set; }

    public DateTime? DeletedAt { get; set; }
    [Display(Name = "Correo electrónico")]

    public string Email { get; set; } = null!;
    [Display(Name = "Primer nombre")]

    public string FirstName { get; set; } = null!;
    [Display(Name = "Género")]

    public string? Gender { get; set; }
    [Display(Name = "Altura (cm)")]

    public double? Height { get; set; }
    [Display(Name = "Primer apellido")]

    public string LastName { get; set; } = null!;
    [Display(Name = "Contraseña")]

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;
    [Display(Name = "Segundo apellido")]

    public string? SecondLastName { get; set; }

    public string? SecondName { get; set; }
    [Display(Name = "Nombre de usuario")]

    public string Username { get; set; } = null!;
    [Display(Name = "Peso (kg)")]

    public double? Weight { get; set; }

    public ulong? EmailVerified { get; set; }

    public DateTime? PasswordUpdatedAt { get; set; }

    public string? ResetPasswordToken { get; set; }

    public DateTime? ResetPasswordTokenExpiry { get; set; }

    public string? VerificationToken { get; set; }

    public DateTime? VerificationTokenExpiry { get; set; }

    public string? AvatarPublicId { get; set; }

    public string? AvatarUrl { get; set; }

    public string? BannerPublicId { get; set; }

    public string? BannerUrl { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CommunityMembership> CommunityMemberships { get; set; } = new List<CommunityMembership>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual ICollection<Post> PostAuthors { get; set; } = new List<Post>();

    public virtual ICollection<Post> PostUsuarioDestinos { get; set; } = new List<Post>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<UserFitnessHistory> UserFitnessHistories { get; set; } = new List<UserFitnessHistory>();
}

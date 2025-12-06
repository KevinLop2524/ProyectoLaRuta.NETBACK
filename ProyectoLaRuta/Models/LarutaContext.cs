using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProyectoLaRuta.Models;

public partial class LarutaContext : DbContext
{
    public LarutaContext()
    {
    }

    public LarutaContext(DbContextOptions<LarutaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<CommunityMembership> CommunityMemberships { get; set; }

    public virtual DbSet<Comunidad> Comunidads { get; set; }

    public virtual DbSet<ComunidadUsuario> ComunidadUsuarios { get; set; }

    public virtual DbSet<ComunidadUsuario1> ComunidadUsuarios1 { get; set; }

    public virtual DbSet<ImageFile> ImageFiles { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFitnessHistory> UserFitnessHistories { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comments");

            entity.HasIndex(e => e.ParentCommentId, "FK7h839m3lkvhbyv3bcdv7sm4fj");

            entity.HasIndex(e => e.UserId, "FK8omq0tc18jd43bu5tjh6jvraq");

            entity.HasIndex(e => e.PostId, "FKbqnvawwwv4gtlctsi3o7vs131");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasColumnType("bit(1)")
                .HasColumnName("activo");
            entity.Property(e => e.Contenido)
                .HasMaxLength(1000)
                .HasColumnName("contenido");
            entity.Property(e => e.FechaActualizacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.LikesCount).HasColumnName("likes_count");
            entity.Property(e => e.ParentCommentId).HasColumnName("parent_comment_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment)
                .HasForeignKey(d => d.ParentCommentId)
                .HasConstraintName("FK7h839m3lkvhbyv3bcdv7sm4fj");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKbqnvawwwv4gtlctsi3o7vs131");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK8omq0tc18jd43bu5tjh6jvraq");
        });

        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("communities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.AllowsPosts)
                .HasColumnType("bit(1)")
                .HasColumnName("allows_posts");
            entity.Property(e => e.BannerPublicId)
                .HasMaxLength(200)
                .HasColumnName("banner_public_id");
            entity.Property(e => e.BannerUrl)
                .HasMaxLength(500)
                .HasColumnName("banner_url");
            entity.Property(e => e.Category)
                .HasColumnType("enum('FITNESS','NUTRITION','PERSONAL_DEVELOPMENT')")
                .HasColumnName("category");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.DateOfCreation)
                .HasMaxLength(6)
                .HasColumnName("date_of_creation");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(6)
                .HasColumnName("deleted_at");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.LogoPublicId)
                .HasMaxLength(200)
                .HasColumnName("logo_public_id");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(500)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PostRules)
                .HasColumnType("text")
                .HasColumnName("post_rules");
        });

        modelBuilder.Entity<CommunityMembership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("community_memberships");

            entity.HasIndex(e => e.UserId, "FKgju0tl907079t8q0uo730jm82");

            entity.HasIndex(e => new { e.CommunityId, e.UserId }, "UK31crb04sfw3hii1grpih8t5l2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.JoinedAt)
                .HasMaxLength(6)
                .HasColumnName("joined_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityMemberships)
                .HasForeignKey(d => d.CommunityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKhuw0q35omchguvw829no1pdv4");

            entity.HasOne(d => d.User).WithMany(p => p.CommunityMemberships)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgju0tl907079t8q0uo730jm82");
        });

        modelBuilder.Entity<Comunidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comunidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCreador).HasColumnName("id_creador");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Tematica)
                .HasMaxLength(255)
                .HasColumnName("tematica");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('CHAT_GRUPAL','COMUNIDAD','GRAN_COMUNIDAD','GRUPO')")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<ComunidadUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comunidad_usuario");

            entity.HasIndex(e => e.ComunidadId, "FK8pjexoxo8r2o6kva1uhgqbc4w");

            entity.HasIndex(e => e.UsuarioId, "FKfg2iqsfghkaik8kvhlsyc7m18");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComunidadId).HasColumnName("comunidad_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Comunidad).WithMany(p => p.ComunidadUsuarios)
                .HasForeignKey(d => d.ComunidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK8pjexoxo8r2o6kva1uhgqbc4w");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ComunidadUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKfg2iqsfghkaik8kvhlsyc7m18");
        });

        modelBuilder.Entity<ComunidadUsuario1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("comunidad_usuarios");

            entity.HasIndex(e => e.UsuariosId, "FK3nkpehjwyfw63snynaslegfcg");

            entity.HasIndex(e => e.ComunidadesId, "FKaid6keorgd5tsa6c7905k1o5o");

            entity.Property(e => e.ComunidadesId).HasColumnName("comunidades_id");
            entity.Property(e => e.UsuariosId).HasColumnName("usuarios_id");

            entity.HasOne(d => d.Comunidades).WithMany()
                .HasForeignKey(d => d.ComunidadesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKaid6keorgd5tsa6c7905k1o5o");

            entity.HasOne(d => d.Usuarios).WithMany()
                .HasForeignKey(d => d.UsuariosId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3nkpehjwyfw63snynaslegfcg");
        });

        modelBuilder.Entity<ImageFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("image_file");

            entity.HasIndex(e => e.CreatedAt, "idx_imagefile_created");

            entity.HasIndex(e => e.UserId, "idx_imagefile_user");

            entity.HasIndex(e => e.Filename, "uq_imagefile_filename").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .HasColumnName("categoria");
            entity.Property(e => e.ContentType)
                .HasMaxLength(255)
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Filename).HasColumnName("filename");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('CHAT_GRUPAL','COMUNIDAD','GRAN_COMUNIDAD','GRUPO')")
                .HasColumnName("tipo");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ImageFiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKjub7jh90fi3ltdncixs4f6wi4");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("likes");

            entity.HasIndex(e => e.UserId, "fk_like_user");

            entity.HasIndex(e => new { e.PostId, e.UserId }, "uk_like_post_user").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.LikesNavigation)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_like_post");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_like_user");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post");

            entity.HasIndex(e => e.AuthorId, "FK1mpebp1ayl0twrwm7ruiof778");

            entity.HasIndex(e => e.CommunityId, "FKbq8sqiytubaf9nswqm77tpa44");

            entity.HasIndex(e => e.UsuarioDestinoId, "FKixpkm80leprfn0lvnuwhpn8h");

            entity.HasIndex(e => e.ServiceId, "FKonbuu5ko2934qjn0o26mf0yg2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Comentarios).HasColumnName("comentarios");
            entity.Property(e => e.CommunityId).HasColumnName("community_id");
            entity.Property(e => e.Compartidos).HasColumnName("compartidos");
            entity.Property(e => e.Contenido)
                .HasMaxLength(2000)
                .HasColumnName("contenido");
            entity.Property(e => e.FechaActualizacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.HasMedia)
                .HasColumnType("bit(1)")
                .HasColumnName("has_media");
            entity.Property(e => e.ImagePublicId)
                .HasMaxLength(200)
                .HasColumnName("image_public_id");
            entity.Property(e => e.ImageThumbnailUrl)
                .HasMaxLength(500)
                .HasColumnName("image_thumbnail_url");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .HasColumnName("image_url");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Type)
                .HasColumnType("enum('COMMUNITY','SERVICE','USER')")
                .HasColumnName("type");
            entity.Property(e => e.UsuarioDestinoId).HasColumnName("usuario_destino_id");

            entity.HasOne(d => d.Author).WithMany(p => p.PostAuthors)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1mpebp1ayl0twrwm7ruiof778");

            entity.HasOne(d => d.Community).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FKbq8sqiytubaf9nswqm77tpa44");

            entity.HasOne(d => d.Service).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FKonbuu5ko2934qjn0o26mf0yg2");

            entity.HasOne(d => d.UsuarioDestino).WithMany(p => p.PostUsuarioDestinos)
                .HasForeignKey(d => d.UsuarioDestinoId)
                .HasConstraintName("FKixpkm80leprfn0lvnuwhpn8h");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("categoria");
            entity.Property(e => e.Contenido)
                .HasMaxLength(255)
                .HasColumnName("contenido");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reporte");

            entity.HasIndex(e => e.ComunidadId, "FK2nwnex2eirmsfgomujhsjqr6p");

            entity.HasIndex(e => e.UsuarioId, "FKfgof8ktqauqq5c4e8xhc98xae");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("categoria");
            entity.Property(e => e.ComunidadId).HasColumnName("comunidad_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Comunidad).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.ComunidadId)
                .HasConstraintName("FK2nwnex2eirmsfgomujhsjqr6p");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FKfgof8ktqauqq5c4e8xhc98xae");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Name, "UKofx66keruapi6vyqpv6f2or37").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.UserId, "FKmauqobewmd57ylq7ck6wprgkt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasMaxLength(6)
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('ENTRENAMIENTO','NUTRICION','OTRO')")
                .HasColumnName("tipo");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Services)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKmauqobewmd57ylq7ck6wprgkt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UK6dotkott2kjsp8vw4d0m25fb7").IsUnique();

            entity.HasIndex(e => e.Username, "UKr43af9ap4edm43mmtq01oddj6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasColumnType("bit(1)")
                .HasColumnName("active");
            entity.Property(e => e.AvatarPublicId)
                .HasMaxLength(200)
                .HasColumnName("avatar_public_id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(500)
                .HasColumnName("avatar_url");
            entity.Property(e => e.BannerPublicId)
                .HasMaxLength(200)
                .HasColumnName("banner_public_id");
            entity.Property(e => e.BannerUrl)
                .HasMaxLength(500)
                .HasColumnName("banner_url");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfCreation)
                .HasMaxLength(6)
                .HasColumnName("date_of_creation");
            entity.Property(e => e.DeletedAt)
                .HasMaxLength(6)
                .HasColumnName("deleted_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerified)
                .HasColumnType("bit(1)")
                .HasColumnName("email_verified");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PasswordUpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("password_updated_at");
            entity.Property(e => e.ResetPasswordToken)
                .HasMaxLength(100)
                .HasColumnName("reset_password_token");
            entity.Property(e => e.ResetPasswordTokenExpiry)
                .HasMaxLength(6)
                .HasColumnName("reset_password_token_expiry");
            entity.Property(e => e.Role)
                .HasMaxLength(7)
                .HasColumnName("role");
            entity.Property(e => e.SecondLastName)
                .HasMaxLength(50)
                .HasColumnName("second_last_name");
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .HasColumnName("second_name");
            entity.Property(e => e.Username)
                .HasMaxLength(70)
                .HasColumnName("username");
            entity.Property(e => e.VerificationToken)
                .HasMaxLength(100)
                .HasColumnName("verification_token");
            entity.Property(e => e.VerificationTokenExpiry)
                .HasMaxLength(6)
                .HasColumnName("verification_token_expiry");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<UserFitnessHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_fitness_history");

            entity.HasIndex(e => e.UserId, "FKgkakt7qamlnyh7bhjeuv4ionm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArmMeasurement).HasColumnName("arm_measurement");
            entity.Property(e => e.BodyFatPercentage).HasColumnName("body_fat_percentage");
            entity.Property(e => e.ChestMeasurement).HasColumnName("chest_measurement");
            entity.Property(e => e.HipMeasurement).HasColumnName("hip_measurement");
            entity.Property(e => e.RecordDate).HasColumnName("record_date");
            entity.Property(e => e.ThighMeasurement).HasColumnName("thigh_measurement");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WaistMeasurement).HasColumnName("waist_measurement");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.User).WithMany(p => p.UserFitnessHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKgkakt7qamlnyh7bhjeuv4ionm");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "UK2mlfr087gb1ce55f2j87o74t").IsUnique();

            entity.HasIndex(e => e.Apodo, "UKt210h679wbcia9x61rkwnhq8y").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(255)
                .HasColumnName("apellido_2");
            entity.Property(e => e.Apodo).HasColumnName("apodo");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.Localidad)
                .HasMaxLength(255)
                .HasColumnName("localidad");
            entity.Property(e => e.Nacimiento)
                .HasMaxLength(255)
                .HasColumnName("nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(255)
                .HasColumnName("nombre_2");
            entity.Property(e => e.Sexo)
                .HasMaxLength(255)
                .HasColumnName("sexo");

            entity.HasMany(d => d.Roles).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKtk4qndf0xt1ijkk4a7wj5vnwb"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKqblnumndby0ftm4c7sg6uso6p"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("usuario_roles");
                        j.HasIndex(new[] { "RoleId" }, "FKtk4qndf0xt1ijkk4a7wj5vnwb");
                        j.IndexerProperty<long>("UsuarioId").HasColumnName("usuario_id");
                        j.IndexerProperty<long>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

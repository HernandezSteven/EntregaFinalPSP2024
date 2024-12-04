using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntregaFinalPSP2024.Models;

public partial class EntregafinalpspContext : DbContext
{
    public EntregafinalpspContext()
    {
    }

    public EntregafinalpspContext(DbContextOptions<EntregafinalpspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<Meta> Metas { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC27E8DCE491");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC2704E76BDA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Comentario1)
                .HasColumnType("text")
                .HasColumnName("Comentario");
            entity.Property(e => e.FechaComentario).HasColumnName("Fecha_Comentario");
            entity.Property(e => e.IdEjercicio).HasColumnName("ID_Ejercicio");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdEjercicioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdEjercicio)
                .HasConstraintName("FK__Comentari__ID_Ej__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Comentari__ID_Us__48CFD27E");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ejercici__3214EC2797F3CFF0");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Dificultad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Ejercicios)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Ejercicio__ID_Ca__3E52440B");
        });

        modelBuilder.Entity<Estadistica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estadist__3214EC270CD16B31");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FechaRealizacion).HasColumnName("Fecha_Realizacion");
            entity.Property(e => e.IdEjercicio).HasColumnName("ID_Ejercicio");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            entity.Property(e => e.Resultado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TiempoEmpleado).HasColumnName("Tiempo_Empleado");

            entity.HasOne(d => d.IdEjercicioNavigation).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.IdEjercicio)
                .HasConstraintName("FK__Estadisti__ID_Ej__4222D4EF");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Estadisti__ID_Us__412EB0B6");
        });

        modelBuilder.Entity<Meta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Metas__3214EC2794D43808");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaLimite).HasColumnName("Fecha_Limite");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Meta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Metas__ID_Usuari__4CA06362");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Progreso__3214EC27E37AC310");

            entity.ToTable("Progreso");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaFinalizacion).HasColumnName("Fecha_Finalizacion");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdEjercicio).HasColumnName("ID_Ejercicio");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdEjercicioNavigation).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.IdEjercicio)
                .HasConstraintName("FK__Progreso__ID_Eje__45F365D3");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Progreso__ID_Usu__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27A5A08026");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC2731B1311C");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.Nivel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__ID_Rol__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiBiblioteca2.DataAdapter.Models;

namespace WebApiBiblioteca2.DataAdapter
{
    public partial class WebApiBiblioteca2_DbContext : DbContext
    {

        public WebApiBiblioteca2_DbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<AutorModels> Autors { get; set; }
        public virtual DbSet<ComentarioModels> Comentarios { get; set; }
        public virtual DbSet<LibroModels> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorModels>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ComentarioModels>(entity =>
            {
                entity.Property(e => e.Comentario)
                    .IsUnicode(false)
                    .HasColumnName("Comentario");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.LibroId)
                    .HasConstraintName("FK__Comentari__Libro__29572725");
            });

            modelBuilder.Entity<LibroModels>(entity =>
            {
                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK__Libros__AutorId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

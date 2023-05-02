using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiBiblioteca2.DataAdapter.Models;

namespace WebApiBiblioteca2.DataAdapter
{
    public partial class WebApiBiblioteca2_DbContext : IdentityDbContext
    {

        public WebApiBiblioteca2_DbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<AutorModels> Autors { get; set; }
        public virtual DbSet<ComentarioModels> Comentarios { get; set; }
        public virtual DbSet<LibroModels> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }    

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

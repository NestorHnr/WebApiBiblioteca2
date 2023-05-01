using System;
using System.Collections.Generic;

namespace WebApiBiblioteca2.DataAdapter.Models
{
    public partial class LibroModels
    {
        public LibroModels()
        {
            Comentarios = new HashSet<ComentarioModels>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? AutorId { get; set; }

        public virtual AutorModels Autor { get; set; }
        public virtual ICollection<ComentarioModels> Comentarios { get; set; }
    }
}

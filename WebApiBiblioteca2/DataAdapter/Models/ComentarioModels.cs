using System;
using System.Collections.Generic;

namespace WebApiBiblioteca2.DataAdapter.Models
{
    public partial class ComentarioModels
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? LibroId { get; set; }

        public virtual LibroModels Libro { get; set; }
    }
}

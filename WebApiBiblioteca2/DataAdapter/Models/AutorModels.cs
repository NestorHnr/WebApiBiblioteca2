using System;
using System.Collections.Generic;

namespace WebApiBiblioteca2.DataAdapter.Models
{
    public partial class AutorModels
    {
        public AutorModels()
        {
            Libros = new HashSet<LibroModels>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<LibroModels> Libros { get; set; }
    }
}

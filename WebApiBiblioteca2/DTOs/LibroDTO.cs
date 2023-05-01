using WebApiBiblioteca2.DataAdapter.Models;

namespace WebApiBiblioteca2.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? AutorId { get; set; }

        public virtual AutorModels Autor { get; set; }
        public virtual ICollection<ComentarioModels> Comentarios { get; set; }
    }
}

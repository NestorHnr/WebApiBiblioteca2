using WebApiBiblioteca2.DataAdapter.Models;

namespace WebApiBiblioteca2.DTOs
{
    public class AutorDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<LibroModels> Libros { get; set; }
    }
}

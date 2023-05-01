using WebApiBiblioteca2.DataAdapter.Models;

namespace WebApiBiblioteca2.DTOs
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? LibroId { get; set; }


    }
}

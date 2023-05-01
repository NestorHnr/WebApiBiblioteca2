using System.ComponentModel.DataAnnotations;

namespace WebApiBiblioteca2.DTOs
{
    public class CreateLibroDTO
    {
        [Required]
        public string Nombre { get; set; }


        public string Genero { get; set; }
        
        [Required]
        public int AutorId { get; set; }

    }
}

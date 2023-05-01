using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.Ports
{
    public interface ILibroRepositoryPorts
    {

        Task CreateLibro(CreateLibroDTO libro);
        Task DeleteLibro(int id);
        Task UpdateLibro(UpdateLibroDTO libro);
        Task<LibroDTO> GetLibroById(int id);
        Task<LibroDTO> GetLibroByName(string name);
        Task<List<LibroDTO>> GetAll();
    }
}

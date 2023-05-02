using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.Ports
{
    public interface IComentarioRepositoryPorts
    {
        Task CreateComentario(CreateComentarioDTO comentario);
        Task DeleteComentario(int id);
        Task UpdateComentario(UpdateComentarioDTO comentario);
        Task<ComentarioDTO> GetComentarioById(int id);
        Task<List<ComentarioDTO>> GetAll(int libroId);
    }
}

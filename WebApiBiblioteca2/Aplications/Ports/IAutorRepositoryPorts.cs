using WebApiBiblioteca2.DataAdapter.Models;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.Ports
{
    public interface IAutorRepositoryPorts
    {
        Task CreateAutor(CreateAutorDTO autor);
        Task DeleteAutor(int id);
        Task UpdateAutor(UpdateAutorDTO autor);
        Task<AutorDTO> GetAutorById(int id);
        Task<List<AutorDTO>> GetAutorByName(string name);
        Task<List<AutorDTO>> GetAll();

    }
}

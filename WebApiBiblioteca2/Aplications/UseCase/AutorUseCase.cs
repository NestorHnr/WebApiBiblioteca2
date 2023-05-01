using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.UseCase
{
    public class AutorUseCase
    {
        private readonly IAutorRepositoryPorts _autorRepositoryPorts;

        public AutorUseCase(IAutorRepositoryPorts autorRepositoryPorts)
        {
            _autorRepositoryPorts = autorRepositoryPorts;
        }

        public async Task CreateAutor(CreateAutorDTO autor) => await _autorRepositoryPorts.CreateAutor(autor);
        public async Task DeleteAutor(int id) => await _autorRepositoryPorts.DeleteAutor(id);
        public async Task UpdateAutor(UpdateAutorDTO autor) => await _autorRepositoryPorts.UpdateAutor(autor);
        public async Task GetAutorById(int id) => await _autorRepositoryPorts.GetAutorById(id);
        public async Task GetAutorByName(string name) => await _autorRepositoryPorts.GetAutorByName(name);
        public async Task GetAll() => await _autorRepositoryPorts.GetAll();

        
    }
}

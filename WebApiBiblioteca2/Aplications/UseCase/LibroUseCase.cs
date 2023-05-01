using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.UseCase
{
    public class LibroUseCase
    {
        private readonly ILibroRepositoryPorts _libroRepositoryPorts;

        public LibroUseCase(ILibroRepositoryPorts libroRepositoryPorts)
        {
            _libroRepositoryPorts = libroRepositoryPorts;
        }

        public async Task CreateLibro(CreateLibroDTO libro) => await _libroRepositoryPorts.CreateLibro(libro);
        public async Task DeleteLibro(int id) => await _libroRepositoryPorts.DeleteLibro(id);
        public async Task UpdateLibro(UpdateLibroDTO libro) => await _libroRepositoryPorts.UpdateLibro(libro);
        public async Task GetLibroById(int id) => await _libroRepositoryPorts.GetLibroById(id);
        public async Task GetLibroByName(string name) => await _libroRepositoryPorts.GetLibroByName(name);
        public async Task GetAll() => await _libroRepositoryPorts.GetAll();


    }
}

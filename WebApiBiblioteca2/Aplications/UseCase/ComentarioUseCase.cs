using System.Runtime.CompilerServices;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Aplications.UseCase
{
    public class ComentarioUsecase
    {
        private readonly IComentarioRepositoryPorts _comentarioRepositoryPorts;

        public ComentarioUsecase(IComentarioRepositoryPorts comentarioRepositoryPorts)
        {
           _comentarioRepositoryPorts = comentarioRepositoryPorts;
        }

        public async Task Createcomentario(CreateComentarioDTO comentario) => await _comentarioRepositoryPorts.CreateComentario(comentario);
        public async Task DeleteComentario(int id) => await _comentarioRepositoryPorts.DeleteComentario(id);
        public async Task UpdateComentartio(UpdateComentarioDTO comentario) => await _comentarioRepositoryPorts.UpdateComentario(comentario);
        public async Task GetComentarioById(int id) => await _comentarioRepositoryPorts.GetComentarioById(id);
        public async Task GetAll() => await _comentarioRepositoryPorts.GetAll();
    }
}

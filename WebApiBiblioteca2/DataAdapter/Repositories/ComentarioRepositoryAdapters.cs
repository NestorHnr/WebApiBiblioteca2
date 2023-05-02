using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DataAdapter.Models;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.DataAdapter.Repositories
{
    public class ComentarioRepositoryAdapters : IComentarioRepositoryPorts
    {
        private readonly WebApiBiblioteca2_DbContext _context;
        private readonly IMapper _mapper;

        public ComentarioRepositoryAdapters(WebApiBiblioteca2_DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateComentario(CreateComentarioDTO comentarioDto)
        {
            //var extisteLibro = await _context.Libros.AnyAsync(libroDB => libroDB.Id == libroDB.Id);

            //if (!extisteLibro)
            //    throw new Exception($"No existe libro con ese Id");

            var comentarioMap = _mapper.Map<ComentarioModels>(comentarioDto);

            //comentarioMap.LibroId = libroId;
            _context.Add(comentarioMap);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComentario(int id)
        {
            var validacion = await _context.Comentarios.AnyAsync(x => x.Id == id);
            if (!validacion)
                throw new Exception($"El comentario con el Id {id} No existe");

            _context.Comentarios.Remove(new ComentarioModels() { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<List<ComentarioDTO>> GetAll(int libroId )
        {
            var extisteLibro = await _context.Libros.AnyAsync(libroDB => libroDB.Id == libroDB.Id);

            if (!extisteLibro)
                throw new Exception($"No existe libro con ese id");

            var comentarios = await _context.Comentarios
                .Where(comentarioDB => comentarioDB.LibroId == libroId).ToListAsync();

            //var comentarioList = await _context.Comentarios.ToListAsync();

            //if (comentarioList.Count == 0)
            //    throw new Exception("No hay comentarios disponibles");

            var comentario = _mapper.Map<List<ComentarioDTO>>(comentarios);

            return comentario;
        }

        public async Task<ComentarioDTO> GetComentarioById(int id)
        {
            var coment = await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);

            if (coment == null)
                throw new Exception($"No se encuentra comentario registrado con el id {id}");

            var comentId = _mapper.Map<ComentarioDTO>(coment);

            return comentId;
        }

        public async Task UpdateComentario(UpdateComentarioDTO comentatioDto)
        {
            var validacion = await _context.Comentarios.AnyAsync(x => x.Id ==  comentatioDto.Id);

            if (!validacion)
                throw new Exception($"Comentario con el id {comentatioDto.Id} no existe");

            var comentMap = _mapper.Map<ComentarioModels>(comentatioDto);

            _context.Comentarios.Update(comentMap);
            await _context.SaveChangesAsync();

        }
    }
}

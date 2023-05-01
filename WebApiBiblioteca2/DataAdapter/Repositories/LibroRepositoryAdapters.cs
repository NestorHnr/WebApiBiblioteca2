using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DataAdapter.Models;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.DataAdapter.Repositories
{
    public class LibroRepositoryAdapters : ILibroRepositoryPorts
    {
        private readonly WebApiBiblioteca2_DbContext _context;
        private readonly IMapper _mapper;

        public LibroRepositoryAdapters(WebApiBiblioteca2_DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateLibro(CreateLibroDTO autor)
        {
            var mismoNombre = await _context.Libros.AnyAsync(x => x.Nombre == autor.Nombre);

            if (mismoNombre)
                throw new Exception($"Ya existe un autor con el nombre {autor.Nombre}");

            var person = _mapper.Map<LibroModels>(autor);

            _context.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLibro(int id)
        {
            var validacion = await _context.Libros.AnyAsync(x => x.Id == id);
            if (!validacion)
                throw new Exception($"El Libro con el Id {id} No existe");

            _context.Libros.Remove(new LibroModels() { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<List<LibroDTO>> GetAll()
        {
            var autorList = await _context.Libros.ToListAsync();
 
            if (autorList.Count == 0)
                throw new Exception("No hay autores disponibles");

            var autors = _mapper.Map<List<LibroDTO>>(autorList);

            return autors;
        }

        public async Task<LibroDTO> GetLibroById(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(x => x.Id == id);

            if (libro == null)
                throw new Exception($"No se encuentra autor registrado con el id {id}");

            var libro2 = _mapper.Map<LibroDTO>(libro);

            return libro2;
        }

        public async Task<LibroDTO> GetLibroByName(string name)
        {
            var libro = await _context.Libros.Where(x => x.Nombre.Contains(name)).ToListAsync();

            if (libro == null)
                throw new Exception($"No se encuentra un libro registrado con el nombre de {name}");

            var libro2 = _mapper.Map<LibroDTO>(libro);

            return libro2;
        }

        public async Task UpdateLibro(UpdateLibroDTO libroDto)
        {
            var validacion = await _context.Libros.AnyAsync(x => x.Id == libroDto.Id);

            if (!validacion)
                throw new Exception($"libro con el Id {libroDto.Id} no existe");

            var libro = _mapper.Map<LibroModels>(libroDto);

            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }
    }
}

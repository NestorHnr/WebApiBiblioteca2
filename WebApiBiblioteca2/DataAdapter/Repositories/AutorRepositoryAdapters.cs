using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DataAdapter.Models;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.DataAdapter.Repositories
{
    public class AutorRepositoryAdapters : IAutorRepositoryPorts
    {
        private readonly WebApiBiblioteca2_DbContext _context;
        private readonly IMapper _mapper;

        public AutorRepositoryAdapters(WebApiBiblioteca2_DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAutor(CreateAutorDTO autor)
        {
            var mismoNombre = await _context.Autors.AnyAsync(x => x.Nombre == autor.Nombre);

            if (mismoNombre)
                throw new Exception($"Ya existe un autor con el nombre {autor.Nombre}");

            var person = _mapper.Map<AutorModels>(autor);

            _context.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutor(int id)
        {
            var validacion = await _context.Autors.AnyAsync(x => x.Id == id);
            if (!validacion)
                throw new Exception($"El Autor con el Id {id} No existe");

            _context.Autors.Remove(new AutorModels() { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<List<AutorDTO>> GetAll()
        {
            var autorList = await _context.Autors.ToListAsync();
            //var autors = await _context.Autors.Select(x => new AutorDTO()
            //{
            //    Nombre = x.Nombre

            //}).ToListAsync();

            if (autorList.Count == 0)
                throw new Exception("No hay autores disponibles");

            var autors = _mapper.Map<List<AutorDTO>>(autorList);

            return autors;
        }

        public async Task<AutorDTO> GetAutorById(int id)
        {
            var autor = await _context.Autors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (autor == null)
                throw new Exception($"No se encuentra autor registrado con el id {id}");

            var autor2 = _mapper.Map<AutorDTO>(autor);
            //var autor = await _context.Autors.Where(x => x.Id == id)
            //    .Select(x => new AutorDTO()
            //    {
            //        Nombre = x.Nombre

            //    }
            //    ).FirstOrDefaultAsync();

            return autor2;
        }

        public async Task<List<AutorDTO>> GetAutorByName(string name)
        {
            var autor = await _context.Autors.Where(x => x.Nombre.Contains(name)).ToListAsync();
                
            if (autor.Count == 0)
                throw new Exception($"No se encuentra un autor registrado con el nombre de {name}");

            var autor2 = _mapper.Map<List<AutorDTO>>(autor);

            return autor2;
        }

        public async Task UpdateAutor(UpdateAutorDTO autor)
        {
            var validacion = await _context.Autors.AnyAsync(x => x.Id == autor.Id);

            if (!validacion)
                throw new Exception($"Autor con el Id {autor.Id} no existe");

            var person = _mapper.Map<AutorModels>(autor);
            //AutorModels person = new AutorModels()
            //{
            //    Id = autor.Id,
            //    Nombre = autor.Nombre,
            //};

            _context.Autors.Update(person);
            await _context.SaveChangesAsync();
        }
    }
}

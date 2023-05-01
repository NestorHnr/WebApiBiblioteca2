using AutoMapper;
using WebApiBiblioteca2.DataAdapter.Models;
using WebApiBiblioteca2.DTOs;

namespace WebApiBiblioteca2.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<CreateAutorDTO, AutorModels>().ReverseMap();
            CreateMap<CreateComentarioDTO, ComentarioModels>().ReverseMap();
            CreateMap<CreateLibroDTO, LibroModels>().ReverseMap();
            CreateMap<UpdateAutorDTO, AutorModels>().ReverseMap();
            CreateMap<UpdateComentarioDTO, ComentarioModels>().ReverseMap();
            CreateMap<UpdateLibroDTO, LibroModels>().ReverseMap();
            CreateMap<AutorDTO, AutorModels>().ReverseMap();
            CreateMap<ComentarioDTO, ComentarioModels>().ReverseMap();
            CreateMap<LibroDTO, LibroModels>().ReverseMap();
        }
    }
}

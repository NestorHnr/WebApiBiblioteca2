using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;

namespace WebApiBiblioteca2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        public readonly ILibroRepositoryPorts _libroRepositoryPorts;

        public LibroController(ILibroRepositoryPorts libroRepositoryPorts)
        {
            _libroRepositoryPorts = libroRepositoryPorts;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _libroRepositoryPorts.GetAll();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetLibroById(int id)
        {
            try
            {
                var user = await _libroRepositoryPorts.GetLibroById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{nombre}")]

        public async Task<IActionResult> GetLibroByName(string nombre)
        {
            try
            {
                var user = await _libroRepositoryPorts.GetLibroByName(nombre);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibro(CreateLibroDTO libro)
        {
            try
            {
                await _libroRepositoryPorts.CreateLibro(libro);
                return Ok(new { message = "Registro guardado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLibro(UpdateLibroDTO libroDto)
        {
            try
            {
                await _libroRepositoryPorts.UpdateLibro(libroDto);
                return Ok(new { message = "Registro actualizado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteLibro(int id)
        {
            try
            {
                await _libroRepositoryPorts.DeleteLibro(id);
                return Ok(new { message = $"Libro con el Id {id} eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

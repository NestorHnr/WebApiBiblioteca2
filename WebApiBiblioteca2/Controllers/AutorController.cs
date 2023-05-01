using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;
using WebApiBiblioteca2.models;

namespace WebApiBiblioteca2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        public readonly IAutorRepositoryPorts _autorRepositoryPorts;

        public AutorController(IAutorRepositoryPorts autorRepositoryPorts)
        {
            _autorRepositoryPorts = autorRepositoryPorts;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _autorRepositoryPorts.GetAll();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetAutorById(int id)
        {
            try
            {
                var user = await _autorRepositoryPorts.GetAutorById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{nombre}")]

        public async Task<IActionResult> GetAutorByName(string nombre)
        {
            try
            {
                var user = await _autorRepositoryPorts.GetAutorByName(nombre);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateAutorDTO autor)
        {
            try
            {
                await _autorRepositoryPorts.CreateAutor(autor);
                return Ok(new { message = "Registro guardado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutor(UpdateAutorDTO autor)
        {
            try
            {
                await _autorRepositoryPorts.UpdateAutor(autor);
                return Ok(new { message = "Registro actualizado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteAutor(int id)
        {
            try
            {
                await _autorRepositoryPorts.DeleteAutor(id);
                return Ok(new { message = $"Autor con el Id {id} eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

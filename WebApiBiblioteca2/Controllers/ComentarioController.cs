using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBiblioteca2.Aplications.Ports;
using WebApiBiblioteca2.DTOs;

namespace WebApiBiblioteca2.Controllers
{
    [Route("api/libro{LibroId:int}/comentario")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        public readonly IComentarioRepositoryPorts _comentarioRepositoryPorts;

        public ComentarioController(IComentarioRepositoryPorts comentarioRepositoryPorts)
        {
           _comentarioRepositoryPorts = comentarioRepositoryPorts;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll(int libroId)
        {
            try
            {
                var user = await _comentarioRepositoryPorts.GetAll(libroId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetComentarioById(int id)
        {
            try
            {
                var user = await _comentarioRepositoryPorts.GetComentarioById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateComentario(CreateComentarioDTO comentarioDto)
        {
            try
            {
                await _comentarioRepositoryPorts.CreateComentario(comentarioDto);
                return Ok(new { message = "comentario guardado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComentario(UpdateComentarioDTO comentarioDto)
        {
            try
            {
                await _comentarioRepositoryPorts.UpdateComentario(comentarioDto);
                return Ok(new { message = "Comentario actualizado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteComentario(int id)
        {
            try
            {
                await _comentarioRepositoryPorts.DeleteComentario(id);
                return Ok(new { message = $"Comentario con el Id {id} eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

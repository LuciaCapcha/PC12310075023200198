using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Entities;
using PC1.CORE.Infrastructure.Data;

namespace PC12310075023200198.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoServicioController : ControllerBase
    {
        private readonly TallerMecanicoDbContext _dbContext;

        public TipoServicioController(TallerMecanicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Obtiene todos los tipos de servicio
        /// </summary>
        /// <returns>Lista de tipos de servicio</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoServicio>>> GetAll()
        {
            var tiposServicio = await _dbContext.TipoServicios.ToListAsync();
            return Ok(tiposServicio);
        }

        /// <summary>
        /// Obtiene un tipo de servicio por su ID
        /// </summary>
        /// <param name="id">ID del tipo de servicio</param>
        /// <returns>Tipo de servicio encontrado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicio>> GetById(int id)
        {
            var tipoServicio = await _dbContext.TipoServicios.FindAsync(id);

            if (tipoServicio == null)
            {
                return NotFound(new { mensaje = $"El tipo de servicio con ID {id} no existe." });
            } 

            return Ok(tipoServicio);
        }

        /// <summary>
        /// Crea un nuevo tipo de servicio
        /// </summary>
        /// <param name="tipoServicio">Datos del tipo de servicio a crear</param>
        /// <returns>Tipo de servicio creado</returns>
        [HttpPost]
        public async Task<ActionResult<TipoServicio>> Create([FromBody] TipoServicio tipoServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.TipoServicios.Add(tipoServicio);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tipoServicio.Id }, tipoServicio);
        }

        /// <summary>
        /// Actualiza un tipo de servicio existente
        /// </summary>
        /// <param name="id">ID del tipo de servicio a actualizar</param>
        /// <param name="tipoServicio">Nuevos datos del tipo de servicio</param>
        /// <returns>Tipo de servicio actualizado</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoServicio tipoServicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoServicioExistente = await _dbContext.TipoServicios.FindAsync(id);

            if (tipoServicioExistente == null)
            {
                return NotFound(new { mensaje = $"El tipo de servicio con ID {id} no existe." });
            }

            tipoServicioExistente.Nombre = tipoServicio.Nombre;
            tipoServicioExistente.PrecioBase = tipoServicio.PrecioBase;

            _dbContext.TipoServicios.Update(tipoServicioExistente);
            await _dbContext.SaveChangesAsync();

            return Ok(new { mensaje = "Tipo de servicio actualizado exitosamente.", dato = tipoServicioExistente });
        }

        /// <summary>
        /// Elimina un tipo de servicio
        /// </summary>
        /// <param name="id">ID del tipo de servicio a eliminar</param>
        /// <returns>Mensaje de confirmación</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoServicio = await _dbContext.TipoServicios.FindAsync(id);

            if (tipoServicio == null)
            {
                return NotFound(new { mensaje = $"El tipo de servicio con ID {id} no existe." });
            }

            _dbContext.TipoServicios.Remove(tipoServicio);
            await _dbContext.SaveChangesAsync();

            return Ok(new { mensaje = $"Tipo de servicio con ID {id} eliminado exitosamente." });
        }
    }
}

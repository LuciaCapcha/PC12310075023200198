using Microsoft.AspNetCore.Mvc;
using PC1.CORE.Core.DTOs;
using PC1.CORE.Core.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PC12310075023200198.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenServicioController : ControllerBase
    {
        private readonly IOrdenServicioService _service;

        public OrdenServicioController(IOrdenServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<OrdenServicioDto>> Get()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicioDto>> Get(int id)
        {
            var dto = await _service.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<OrdenServicioDto>> Post([FromBody] OrdenServicioDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrdenServicioDto dto)
        {
            if (id != dto.Id) return BadRequest();
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

using GestaoResiduo.Models;
using GestaoResiduo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoResiduo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResiduosController : ControllerBase
    {
        private readonly IResiduoService _service;

        public ResiduosController(IResiduoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residuo>>> Get()
        {
            var residuos = await _service.ListarTodosAsync();
            return Ok(residuos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Residuo>> GetById(int id)
        {
            var residuo = await _service.BuscarPorIdAsync(id);
            if (residuo == null)
                return NotFound();

            return Ok(residuo);
        }

        [HttpPost]
        public async Task<ActionResult<Residuo>> Post([FromBody] Residuo residuo)
        {
            var criado = await _service.CriarAsync(residuo);
            return CreatedAtAction(nameof(GetById), new { id = criado.IdResiduo }, criado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Residuo residuo)
        {
            residuo.IdResiduo = id;
            var atualizado = await _service.AtualizarAsync(residuo);
            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _service.DeletarAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}

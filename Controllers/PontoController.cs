using Microsoft.AspNetCore.Mvc;
using SistemaDePonto.Data;
using SistemaDePonto.Models;

namespace SistemaDePonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly PontoContext _context;

        public PontoController()
        {
            _context = new PontoContext();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetPontos());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Ponto? ponto = _context.GetById(id);
            if (ponto is null)
            {
                return NotFound();
            }

            return Ok(ponto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Ponto ponto)
        {
            if (ponto == null)
                return BadRequest();

            ponto.Data = DateTime.Now;
            ponto = _context.AddPonto(ponto);
            return CreatedAtAction(nameof(Get), new { id = ponto.Id }, ponto);
        }
        
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] DateTime data)
        {
            _context.UpdatePonto(id, data);
            
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _context.DeletePonto(id);
            
            return NoContent();
        }
    }
}

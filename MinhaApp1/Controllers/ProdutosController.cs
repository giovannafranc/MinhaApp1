using Microsoft.AspNetCore.Mvc;
using MinhaApp1.Models;
using MinhaApp1.Services;
using Microsoft.AspNetCore.Authorization;


namespace MinhaApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _service.GetById(id);

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return Ok(produto);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            var criado = _service.Create(produto);
            return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produto produto)
        {
            var atualizado = _service.Update(id, produto);

            if (atualizado == null)
                return NotFound("Produto não encontrado.");

            return Ok(atualizado);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletado = _service.Delete(id);

            if (!deletado)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}
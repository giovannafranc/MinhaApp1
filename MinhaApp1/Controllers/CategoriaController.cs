using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MinhaApp1.Interfaces;
using MinhaApp1.Dtos;


namespace MinhaApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] CategoriaCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.Create(dto);
            return CreatedAtAction(nameof(Create), new { id = result.Id}, result);
        }
    }
}
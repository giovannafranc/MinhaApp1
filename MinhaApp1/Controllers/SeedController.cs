using Bogus;
using Microsoft.AspNetCore.Mvc;
using MinhaApp1.Data;
using MinhaApp1.Models;

namespace MinhaApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeedController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("popular/{quantidade}")]
        public IActionResult Popular(int quantidade)
        {
            var faker = new Faker<Produto>("pt_BR")
                .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                .RuleFor(p => p.Preco, f => f.Finance.Amount(5, 5000));

            var produtos = faker.Generate(quantidade);

            _context.Produtos.AddRange(produtos);
            _context.SaveChanges();

            return Ok($"{quantidade} produtos inseridos com sucesso!");
        }
    }
}
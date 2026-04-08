using MinhaApp1.Data;
using MinhaApp1.Dtos;
using MinhaApp1.Interfaces;
using MinhaApp1.Models;

namespace MinhaApp1.Services
{
    public class CategoriaService : ICategoriaService
    {

        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public CategoriaResponseDto Create(CategoriaCreateDto dto)
        {
            var categoria = new Categoria
            {
                Nome = dto.Nome,
                Produtos = new List<Produto>()
            };

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CategoriaResponseDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }
    }
}

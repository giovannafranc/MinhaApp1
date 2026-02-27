using MinhaApp1.Data;
using MinhaApp1.DTOs;
using MinhaApp1.Interfaces;
using MinhaApp1.Models;

namespace MinhaApp1.Services
{
    public class ProdutoService: IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context) 
        {
            _context = context;
        }


        public List<ProdutoResponseDto> GetAll()
        {
            return _context.Produtos.
                Select(p => new ProdutoResponseDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                })
                .ToList();
        }

        public ProdutoResponseDto GetById(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null) return null;

            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }

        public ProdutoResponseDto Create(ProdutoCreateDto dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            
            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }

        public ProdutoResponseDto Update(int id, ProdutoCreateDto produtoAtualizado)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) return null;

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            _context.SaveChanges();

            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }

        public bool Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return true;
        }
    }
}

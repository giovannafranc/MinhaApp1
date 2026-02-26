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


        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public Produto Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto Update(int id, Produto produtoAtualizado)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) return null;

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;
            _context.SaveChanges();

            return produto;
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

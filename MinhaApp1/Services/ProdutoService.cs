using MinhaApp1.Interfaces;
using MinhaApp1.Models;

namespace MinhaApp1.Services
{
    public class ProdutoService: IProdutoService
    {
        private static List<Produto> _produtos =
        [
            new() { Id = 1, Nome = "Notebook", Preco = 3500 },
            new() { Id = 2, Nome = "Mouse", Preco = 150 }
        ];

        public List<Produto> GetAll()
        {
            return _produtos;
        }

        public Produto GetById(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public Produto Create(Produto produto)
        {
            produto.Id = _produtos.Count + 1;
            _produtos.Add(produto);
            return produto;
        }

        public Produto Update(int id, Produto produtoAtualizado)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) return null;

            produto.Nome = produtoAtualizado.Nome;
            produto.Preco = produtoAtualizado.Preco;

            return produto;
        }

        public bool Delete(int id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null) return false;

            _produtos.Remove(produto);
            return true;
        }
    }
}

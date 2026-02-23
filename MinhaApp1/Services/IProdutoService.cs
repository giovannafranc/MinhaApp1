using MinhaApp1.Models;

namespace MinhaApp1.Services
{
    public interface IProdutoService
    {
        List<Produto> GetAll();
        Produto GetById(int id);
        Produto Create(Produto produto);
        Produto Update(int id, Produto produto);
        bool Delete(int id);
    }
}

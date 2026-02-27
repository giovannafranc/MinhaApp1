using MinhaApp1.DTOs;
using MinhaApp1.Models;

namespace MinhaApp1.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoResponseDto> GetAll();
        ProdutoResponseDto GetById(int id);
        ProdutoResponseDto Create(ProdutoCreateDto dto);
        ProdutoResponseDto Update(int id, ProdutoCreateDto dto);
        bool Delete(int id);
    }
}

using MinhaApp1.Dtos;

namespace MinhaApp1.Interfaces
{
    public interface ICategoriaService
    {
        CategoriaResponseDto Create(CategoriaCreateDto dto);
    }
}

using System.ComponentModel.DataAnnotations;

namespace MinhaApp1.Dtos
{
    public class CategoriaCreateDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;

namespace MinhaApp1.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório")]
        [StringLength(100, ErrorMessage ="O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}

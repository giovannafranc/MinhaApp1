using System.ComponentModel.DataAnnotations;

namespace MinhaApp1.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo e obrigatorio")]
        [StringLength(100, ErrorMessage ="O nome deve ter no minimo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e obrigatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Preço deve ser maior que zero.")]
        public Decimal Preco { get; set; }

    }
}

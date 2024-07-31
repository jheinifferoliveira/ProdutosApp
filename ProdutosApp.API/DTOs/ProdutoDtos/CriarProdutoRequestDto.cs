using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.API.DTOs.ProdutoDtos
{
    public class CriarProdutoRequestDto
    {
        [MaxLength(50, ErrorMessage = "Digite um nome com no máximo 50 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do Produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage ="Por favor, informe o preço do produto.")]
        public Decimal? Preco { get; set; }

        [Required(ErrorMessage ="Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage ="Por favor, informe o id do fornecedor.")]
        public Guid? FornecedorId { get; set; }
    }
}

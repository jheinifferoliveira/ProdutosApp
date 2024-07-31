using ProdutosApp.Domain.Entities;

namespace ProdutosApp.API.DTOs.ProdutoDtos
{
    public class ConsultarProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public Decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public Guid? FornecedorId { get; set; }

    }
}

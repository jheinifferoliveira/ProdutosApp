namespace ProdutosApp.API.DTOs.ProdutoDtos
{
    public class DeletarProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public Decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public Guid? FornecedorId { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
    }
}

namespace ProdutosApp.API.DTOs
{
    public class AtualizarFornecedorResponseDto
    {
        public string? Nome { get; set; }
        public Guid? Id { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}

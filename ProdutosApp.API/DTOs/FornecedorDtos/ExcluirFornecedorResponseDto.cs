namespace ProdutosApp.API.DTOs
{
    public class ExcluirFornecedorResponseDto
    {
        public string? Nome { get; set; }
        public Guid? Id { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
    }
}

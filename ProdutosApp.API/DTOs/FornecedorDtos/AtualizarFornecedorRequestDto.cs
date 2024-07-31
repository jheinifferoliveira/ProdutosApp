using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.API.DTOs
{
    public class AtualizarFornecedorRequestDto
    {


           [MaxLength(50, ErrorMessage = "Digite um nome com no máximo 50 caracteres.")]
           [Required(ErrorMessage = "Por favor, informe o nome do fornecedor.")]
            public string? Nome { get; set; }

            [Required(ErrorMessage ="Por favor, informe o Id do Fornecedor.")]
            public Guid? Id { get; set; }
            


    }
}

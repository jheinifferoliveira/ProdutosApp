using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ProdutosApp.API.DTOs
{
    public class CriarFornecedorRequestDto
    {
        [MaxLength(50,ErrorMessage ="Digite um nome com no máximo 50 caracteres.")]       
        
        [Required(ErrorMessage ="Por favor, informe o nome do fornecedor.")]
        public string? Nome { get; set; }
    }
}

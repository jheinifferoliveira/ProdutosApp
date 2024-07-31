using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Entities
{
    public class Produto
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }

        #endregion
        #region Chave Estrangeira
        public Guid? FornecedorId { get; set; }
        #endregion

        #region Relacionamento
        public Fornecedor? Fornecedor { get; set; }
        #endregion
    }
}

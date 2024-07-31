using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            var fornecedorEdicao=_fornecedorRepository.GetById((Guid)fornecedor.Id);
            if (fornecedorEdicao == null)
            {
                throw new ApplicationException("O fornecedor não foi encontrado.");
            }
            fornecedorEdicao.Nome=fornecedor.Nome;
            _fornecedorRepository.Update(fornecedorEdicao);
           
           

        }

        public void Cadastrar(Fornecedor fornecedor)
        {

            if (_fornecedorRepository.GetByNome(fornecedor.Nome)!= null)
            {
                throw new ApplicationException("O fornecedor já existe, cadastre outro.");
            }
            _fornecedorRepository.Add(fornecedor);                        
        }

        public Fornecedor? ConsultarPorId(Guid id)
        {
            if (_fornecedorRepository.GetById(id)==null)
            {
                throw new ApplicationException("Nenhum fornecedor encontrado.");
            }
            return _fornecedorRepository.GetById(id);
        }

        public List<Fornecedor> ConsultarTodos()
        {
            if (_fornecedorRepository.GetAll() == null)
            {
                throw new ApplicationException("Nenhum fornecedor encontrado.");
            }
            return _fornecedorRepository.GetAll();
            
            
        }

        public void Excluir(Guid id)
        {
            var fornecedor = _fornecedorRepository.GetById(id);
            if (fornecedor == null)
            {
                throw new ApplicationException("Fornecedor não encontrado.");
            }
            _fornecedorRepository.Delete(fornecedor);
        }
    }
}

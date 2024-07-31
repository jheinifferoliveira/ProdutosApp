using Newtonsoft.Json;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Messages;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMessageProducer _messageProducer;


        public ProdutoService(IProdutoRepository produtoRepository, IMessageProducer messageProducer)
        {
            _produtoRepository = produtoRepository;
            _messageProducer = messageProducer;
        }

        public void Atualizar(Produto produto)
        {
            var produtoAtualizar = _produtoRepository.GetById((Guid)produto.Id);

            if(produtoAtualizar == null)
            {
                throw new ApplicationException("O produto não foi encontrado.");
            }
            produtoAtualizar.Nome = produto.Nome;
            produtoAtualizar.Preco = produto.Preco;
            produtoAtualizar.Quantidade= produto.Quantidade;
            produtoAtualizar.FornecedorId = produto.FornecedorId;
            
            _produtoRepository.Update(produtoAtualizar);
        }

        public void Cadastrar(Produto produto)
        {

            if (_produtoRepository.GetByNome(produto.Nome) != null)
            {
                throw new ApplicationException("O produto já existe, tente outro.");
            }
                _produtoRepository.Add(produto);

                #region Enviar email 
                var mensagem = new Mensagem
                {
                    Destinatario = "jheiniffer2013@gmail.com",
                    Assunto = "Conta de usuário criada com sucesso!",
                    Texto = $"Olá! O produto: {produto.Nome} , foi cadastrado com sucesso no nosso sistema.\n\nAtt\nJheiniffer Oliveira."

                };
                _messageProducer.Send(JsonConvert.SerializeObject(mensagem));
                #endregion
            
        }
        

        public Produto? ConsultarPorId(Guid id)
        {
            if (_produtoRepository.GetById(id) == null)
            {
                throw new ApplicationException("Nenhum produto foi encontrado.");
            }

            return _produtoRepository.GetById(id);
        }

        public List<Produto> ConsultarTodos()
        {
            if(_produtoRepository.GetAll() == null)
            {
                throw new ApplicationException("Não existem produtos cadastrados.");
            }

            return _produtoRepository.GetAll();
        }

        public void Excluir(Guid id)
        {
            var produto=_produtoRepository.GetById(id);
           if(produto == null)
            {
                throw new ApplicationException("Produto não encontrado.");
            }
           _produtoRepository.Delete(produto);

        }

    }
}

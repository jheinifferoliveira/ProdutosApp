using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.DTOs.ProdutoDtos;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
       
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
       
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarProdutoResponseDto), 201)]
        public IActionResult Post(CriarProdutoRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor();
                var produto = new Produto()
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    FornecedorId = dto.FornecedorId
                };
                _produtoService.Cadastrar(produto);


                var response = new CriarProdutoResponseDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    FornecedorId = produto.FornecedorId
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(AtualizarProdutoResponseDto), 200)]
        public IActionResult Put(AtualizarProdutoRequestDto dto)
        {
            try
            {
                var produto = new Produto()
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Preco = dto.Preco,
                    Quantidade = dto.Quantidade,
                    FornecedorId = dto.FornecedorId
                };
                _produtoService.Atualizar(produto);


                var response = new AtualizarProdutoResponseDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    FornecedorId = produto.FornecedorId,
                    DataHoraUltimaAtualizacao = DateTime.Now
                };

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeletarProdutoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto=_produtoService.ConsultarPorId(id);
                _produtoService.Excluir(id);

                var response = new DeletarProdutoResponseDto()
                {
                    Id=produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade= produto.Quantidade,
                    FornecedorId= produto.FornecedorId,
                    DataHoraExclusao= DateTime.Now
                };

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarProdutoResponseDto>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _produtoService.ConsultarTodos();
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
               return StatusCode(422, new {e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(501,new {e.Message });
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarProdutoResponseDto),200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _produtoService.ConsultarPorId(id);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
               return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(501, new {e.Message});
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.DTOs;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarFornecedorResponseDto),201)]
        public IActionResult Post(CriarFornecedorRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor()
                {
                    Id = Guid.NewGuid(),
                    Nome = dto.Nome,                                    
                };
                _fornecedorService.Cadastrar(fornecedor);

                var response = new CriarFornecedorResponseDto()
                {
                    Nome=fornecedor.Nome,
                    Id=fornecedor.Id
                };

                return StatusCode(201,response);
   
            }
            catch(ApplicationException e)
            {
                return StatusCode(422, new {e.Message});
            }

            catch (Exception e)
            {

                return StatusCode(501, new { e.Message });
            }
          
        }

        [HttpPut]
        [ProducesResponseType(typeof(AtualizarFornecedorResponseDto),200)]
        public IActionResult Put(AtualizarFornecedorRequestDto dto)
        {
            try
            {
                var fornecedor = new Fornecedor()
                {

                    Id = dto.Id,
                    Nome = dto.Nome,
                };
                _fornecedorService.Atualizar(fornecedor);
                var response = new AtualizarFornecedorResponseDto()
                {
                    Nome = dto.Nome,
                    Id = fornecedor.Id,
                    DataHoraUltimaAtualizacao = DateTime.Now
                };

                return StatusCode(200,response);
            }
            catch(ApplicationException e)
            {
                return StatusCode (422, new {e.Message});
            }
            catch(Exception e)
            {
                return StatusCode(501, new {e.Message});
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirFornecedorResponseDto),200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var fornecedor = _fornecedorService.ConsultarPorId(id);
                _fornecedorService.Excluir(id);

                var response = new ExcluirFornecedorResponseDto
                {
                    Id = fornecedor.Id,
                    Nome = fornecedor.Nome,
                    DataHoraExclusao = DateTime.Now
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
        [ProducesResponseType(typeof(List<ConsultarFornecedorResponseDto>),200)]
        public IActionResult GetAll()
        {
            try
            {
                var response = _fornecedorService.ConsultarTodos();

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarFornecedorResponseDto),200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _fornecedorService.ConsultarPorId(id);
                
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(501, new { e.Message });
            }
        }
    }
}

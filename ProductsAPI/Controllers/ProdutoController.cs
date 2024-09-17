using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> PesquisaTodosProdutos()
        {
            try
            {
                List<ProdutoModel> produtos = await _produtoRepositorio.PesquisarTodos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }

        // Pesquisa de produto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> PesquisaPorId(int id)
        {
            try
            {
                ProdutoModel produto = await _produtoRepositorio.PesquisarPorId(id);

                if (produto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado.");
                }
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }

        // Registo de produtos
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Registar([FromBody] ProdutoModel produtoModel)
        {
            if (!ModelState.IsValid) // Garantir que os dados do model estão corretos
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
                return Ok(produto); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }

        // Editar produto
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            try
            {
                produtoModel.Id = id;
                ProdutoModel produto = await _produtoRepositorio.Actualizar(produtoModel, id);

                if (produto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado.");
                }

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }

        // Apagar produto
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                bool produtoApagado = await _produtoRepositorio.Apagar(id);

                if (!produtoApagado)
                {
                    return NotFound($"Produto com ID {id} não encontrado.");
                }

                return NoContent(); // Retorna 204 No Content para uma eliminação bem-sucedida
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }
    }
}
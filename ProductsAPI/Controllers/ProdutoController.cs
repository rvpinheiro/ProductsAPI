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


        // Pesquisa de produtos
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> PesquisaTodosProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.PesquisarTodos();
            return Ok(produtos);
        }

        // Pesquisa de produto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoModel>>> PesquisaPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.PesquisarPorId(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        // Registo de produtos
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Registar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        // Editar produto
        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produto = await _produtoRepositorio.Actualizar(produtoModel, id);
            return Ok(produto);
        }

        //Apagar produto
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
            bool produtoApagado = await _produtoRepositorio.Apagar(id);
            return Ok(produtoApagado);
        }
    }
}

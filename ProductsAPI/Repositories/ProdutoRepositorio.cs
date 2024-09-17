using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        // readonly para que não possa ser modificado após construção do objeto
        private readonly SistemaProdutosDBContext _dbContext;

        // injecção de dependência na classe para gerenciar a conexão com a base de dados
        public ProdutoRepositorio(SistemaProdutosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutoModel> PesquisarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> PesquisarTodos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel> Actualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoId = await PesquisarPorId(id);

            if (produtoId == null)
            {
                throw new KeyNotFoundException($"Produto com o id {id} não foi encontrado.");
            }

                produtoId.Nome = produto.Nome;
                produtoId.Tipo = produto.Tipo;
                produtoId.Estado = produto.Estado;
                produtoId.Preco = produto.Preco;
                produtoId.Quantidade = produto.Quantidade;

            _dbContext.Produtos.Update(produtoId);
            await _dbContext.SaveChangesAsync();

            return produtoId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoId = await PesquisarPorId(id);

            if (produtoId == null)
            {
                throw new KeyNotFoundException($"Produto com o id {id} não foi encontrado.");
            }

            _dbContext.Remove(produtoId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Enums;
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

        public async Task<ProdutoModel> Actualizar(ProdutoModel produtoAtualizado, int id)
        {
            ProdutoModel produtoExistente = await PesquisarPorId(id);

            if (produtoExistente == null)
            {
                throw new KeyNotFoundException($"Produto com o id {id} não foi encontrado.");
            }

            // Atualizar os campos relevantes
            if (!string.IsNullOrEmpty(produtoAtualizado.Nome))
            {
                produtoExistente.Nome = produtoAtualizado.Nome;
            }
            if (produtoAtualizado.Tipo != default) // Verifica se o tipo é diferente do valor padrão
            {
                produtoExistente.Tipo = produtoAtualizado.Tipo;
            }
            if (produtoAtualizado.Estado != default) 
            {
                produtoExistente.Estado = produtoAtualizado.Estado;
            }
            if (produtoAtualizado.Preco != default) 
            {
                produtoExistente.Preco = produtoAtualizado.Preco;
            }
            if (produtoAtualizado.Quantidade != default) 
            {
                produtoExistente.Quantidade = produtoAtualizado.Quantidade;
            }

            _dbContext.Produtos.Update(produtoExistente);
            await _dbContext.SaveChangesAsync();

            return produtoExistente;
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

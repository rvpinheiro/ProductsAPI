using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories.Interfaces
{
    public interface IProdutoRepositorio
    {
        // Task -> Operação assincrona 
        Task<List<ProdutoModel>> PesquisarTodos(); 
        Task<ProdutoModel> PesquisarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel utilizador);
        Task<ProdutoModel> Actualizar(ProdutoModel utilizador, int id);
        Task<bool> Apagar(int id);
    }
}

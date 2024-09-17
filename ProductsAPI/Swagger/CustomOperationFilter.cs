using Microsoft.OpenApi.Models;
using ProductsAPI.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class CustomOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Exemplo para alterar descrições de endpoints específicos
        if (context.MethodInfo.DeclaringType == typeof(ProdutoController))
        {
            switch (context.MethodInfo.Name)
            {
                case nameof(ProdutoController.PesquisaTodosProdutos):
                    operation.Summary = "Get de todos os produtos";
                    operation.Description = "Obtém uma lista de todos os produtos.";
                    break;
                case nameof(ProdutoController.PesquisaPorId):
                    operation.Summary = "Get de um produto por ID";
                    operation.Description = "Obtém um produto específico com base no ID fornecido.";
                    break;
                case nameof(ProdutoController.Registar):
                    operation.Summary = "Registar um novo produto";
                    operation.Description = "Adiciona um novo produto.";
                    break;
                case nameof(ProdutoController.Atualizar):
                    operation.Summary = "Atualizar um produto";
                    operation.Description = "Atualiza as informações de um produto existente com base no ID fornecido.";
                    break;
                case nameof(ProdutoController.Apagar):
                    operation.Summary = "Apagar um produto";
                    operation.Description = "Remove um produto com base no ID fornecido.";
                    break;
            }
        }
    }
}

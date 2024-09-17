using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsAPI.Enums;

namespace ProductsAPI.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProdutoModel> builder)
        {
            // Configuração da chave primária
            builder.HasKey(x => x.Id);

            // Configuração da propriedade Nome
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100); // 100 caracteres conforme validação no modelo

            // Configuração da propriedade Tipo
            builder.Property(x => x.Tipo)
                .IsRequired()
                .HasConversion(
                    v => (int)v,   // Converte o enum TipoProduto para int ao salvar
                    v => (TipoProduto)v // Converte o int para o enum TipoProduto ao ler
                );

            // Configuração da propriedade Estado
            builder.Property(x => x.Estado)
                .IsRequired()
                .HasConversion(
                    v => (int)v,   // Converte o enum EstadoProduto para int ao salvar
                    v => (EstadoProduto)v // Converte o int para o enum EstadoProduto ao ler
                );

            // Configuração da propriedade Preço
            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Configurado para 2 casas decimais conforme a validação do modelo

            // Configuração da propriedade Quantidade
            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasDefaultValue(1); // Definindo um valor padrão se necessário
        }
    }
}

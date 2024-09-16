using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data.Map;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Data
{
    public class SistemaProdutosDBContext : DbContext
    {
        public SistemaProdutosDBContext(DbContextOptions<SistemaProdutosDBContext> options)
            : base(options)
        {
        }
        
        public DbSet<ProdutoModel> Produtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

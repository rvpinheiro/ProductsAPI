using ProductsAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoProduto Tipo { get; set; }
        public EstadoProduto Estado { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}

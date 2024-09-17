using ProductsAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "O nome deve conter apenas letras, números e espaços.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public TipoProduto Tipo { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public EstadoProduto Estado { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero e no máximo 999999.99")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "O preço pode ter no máximo duas casas decimais")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser no mínimo 1 e no máximo 10.000")]
        public int Quantidade { get; set; }
    }
}

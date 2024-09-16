using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Enums
{
    public enum EstadoProduto
    {
        Disponivel = 1,    
        Esgotado = 2,      
        Reservado = 3,     
        EmTransito = 4,    
        EmManutencao = 5   
    }
}

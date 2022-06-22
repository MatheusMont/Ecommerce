using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        public async Task<String> AdicionarProduto()
        {
            return "produtinho";
        }
    }
}

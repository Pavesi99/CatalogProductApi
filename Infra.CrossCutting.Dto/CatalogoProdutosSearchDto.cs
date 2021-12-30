using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Dto
{
    public class CatalogoProdutosSearchDto
    {
        public CatalogoProdutosDto CatalogoProdutosSearch { get; set; }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
       
    }
}

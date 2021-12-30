using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class CatalogoProdutosMessage
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeFornecedor { get;  set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get;  set; }
        public int PrecoVenda { get;  set; }
    }
}

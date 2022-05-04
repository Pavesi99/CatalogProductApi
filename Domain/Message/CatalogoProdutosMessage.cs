using Domain.Models;

namespace Domain.Message
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

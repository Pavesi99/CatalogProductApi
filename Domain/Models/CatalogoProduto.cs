namespace Domain.Models
{
    public class CatalogoProduto : Entidade<int>
    {
        public void AtualizarDados(int codigo, string descricao, string nomeFornecedor,  Categoria categoria, int precoVenda)
        {
            Categoria.AtualizarDados(categoria.Codigo, categoria.Nome);
            Codigo = codigo;
            Descricao = descricao;
            NomeFornecedor = nomeFornecedor;
            PrecoVenda = precoVenda;
        }

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public string NomeFornecedor { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public int PrecoVenda { get;  set; }
    }
}

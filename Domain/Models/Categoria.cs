
namespace Domain.Models
{
    public class Categoria : Entidade<int>
    {

        protected Categoria() { }
        public void AtualizarDados(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public int Codigo { get;  set; }
        public string Nome { get;  set; }
    }
}

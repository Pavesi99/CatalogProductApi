using Havan.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Categoria : Entity<int>
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

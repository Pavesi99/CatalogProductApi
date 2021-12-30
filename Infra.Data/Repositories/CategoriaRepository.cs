using Domain.Interfaces.NomeDaBase;
using Infra.CrossCutting.Dto;
using Infra.Data.Config;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Infra.Data.Context;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.ItlSys
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository( CatalogoProdutoContext context) : base(context)
        {
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            if(this.Buscar(categoria.Codigo) == null)
            {
                _dbSet.Add(categoria);
            }else
            {
                _dbSet.Update(categoria);
            }
            return categoria;
        }

        public Categoria Buscar(int categoriaId)
        {
            return  _dbSet.FirstOrDefaultAsync(x => x.Codigo == categoriaId).Result;
        }

        public Categoria Deletar(int categoriaId)
        {
            Categoria categoria = this.Buscar(categoriaId);
            _dbSet.Remove(categoria);
            return categoria;
        }
    }
}

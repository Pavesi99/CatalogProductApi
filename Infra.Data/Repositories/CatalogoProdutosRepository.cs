using Domain.Interfaces.NomeDaBase;
using Infra.CrossCutting.Dto;
using Infra.Data.Config;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Infra.Data.Context;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data.Repositories.ItlSys
{
    public class CatalogoProdutosRepository : Repository<CatalogoProduto>, ICatologoProdutosRepository
    {
        public CatalogoProdutosRepository(CatalogoProdutoContext context) : base(context)
        {
        }

        public CatalogoProduto Buscar(int produtoCodigo)
        {
            return _dbSet.Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Codigo == produtoCodigo).Result;
        }

        public List<CatalogoProduto> Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto)
        {
            IQueryable<CatalogoProduto> query = _dbSet.Include(x => x.Categoria);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.Codigo != 0)
                query = query.Where(x => x.Codigo == catalogoProdutoSearchDto.CatalogoProdutosSearch.Codigo);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.Descricao != string.Empty)
                query = query.Where(x => x.Descricao == catalogoProdutoSearchDto.CatalogoProdutosSearch.Descricao);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.NomeFornecedor != string.Empty)
                query = query.Where(x => x.NomeFornecedor == catalogoProdutoSearchDto.CatalogoProdutosSearch.NomeFornecedor);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.PrecoVenda != 0)
                query = query.Where(x => x.PrecoVenda == catalogoProdutoSearchDto.CatalogoProdutosSearch.PrecoVenda);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.Categoria.Codigo != 0)
                query = query.Where(x => x.Categoria.Codigo == catalogoProdutoSearchDto.CatalogoProdutosSearch.Categoria.Codigo);

            if (catalogoProdutoSearchDto.CatalogoProdutosSearch.Categoria.Nome != string.Empty)
                query = query.Where(x => x.Categoria.Nome == catalogoProdutoSearchDto.CatalogoProdutosSearch.Categoria.Nome);

            return query.Skip((catalogoProdutoSearchDto.Pagina - 1) * catalogoProdutoSearchDto.TamanhoPagina).Take(catalogoProdutoSearchDto.TamanhoPagina).ToList();
        }

        public CatalogoProduto Cadastrar(CatalogoProduto produto)
        {
            var catologoProduto = this.Buscar(produto.Codigo);
            if (catologoProduto != null)
            {
                catologoProduto.AtualizarDados(produto.Codigo, produto.Descricao, produto.NomeFornecedor, produto.Categoria, produto.PrecoVenda);
                _dbSet.Update(catologoProduto);
                return catologoProduto;
            }
            _dbSet.Add(produto);

            return produto;
        }

        public CatalogoProduto Deletar(int produtoId)
        {
            CatalogoProduto produto = this.Buscar(produtoId);
            _dbSet.Remove(produto);
            return produto;
        }
    }
}

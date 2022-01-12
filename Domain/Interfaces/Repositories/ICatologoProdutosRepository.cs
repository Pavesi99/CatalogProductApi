using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Domain.Interfaces.NomeDaBase
{
    public interface ICatologoProdutosRepository : IRepository<CatalogoProduto>
    {
        CatalogoProduto Cadastrar(CatalogoProduto catologoProduto);
        CatalogoProduto Atualizar(CatalogoProduto catologoProduto);
        CatalogoProduto Buscar(int produtoCodigo);
        List<CatalogoProduto> Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto);
        CatalogoProduto Deletar(int produtoId);
    }
}

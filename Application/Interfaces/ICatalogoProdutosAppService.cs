using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICatalogoProdutosAppService
    {
        void IntegrarCatalogo(CatalogoProduto produto);
        List<CatalogoProduto> Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto);
        CatalogoProduto Deletar(int fornecedorId);
    }
}

using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICatalogoProdutosAppService
    {
        void RegistrarCatalogo(CatalogoProduto produto);
        List<CatalogoProduto> Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto);
        CatalogoProduto Deletar(int fornecedorId);
    }
}

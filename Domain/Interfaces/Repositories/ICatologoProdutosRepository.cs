﻿using Domain.Models;
using Havan.Logistica.Core.Repository;
using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.NomeDaBase
{
    public interface ICatologoProdutosRepository : IRepository<CatalogoProduto>
    {
        CatalogoProduto Cadastrar(CatalogoProduto produto);
        CatalogoProduto Buscar(int produtoCodigo);
        List<CatalogoProduto> Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto);
        CatalogoProduto Deletar(int produtoId);
    }
}
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces.NomeDaBase;
using Domain.Interfaces.Uow;
using Domain.Models;
using Infra.CrossCutting.Dto;
using System.Collections.Generic;

namespace Application.Services
{
    public class CatalogoProdutosAppService : ICatalogoProdutosAppService
    {
        private readonly ICatologoProdutosRepository _repository;
        private readonly IUnitOfWork _uow;

        public CatalogoProdutosAppService(ICatologoProdutosRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public void IntegrarCatalogo(CatalogoProduto produto)
        {
            var produtoDb = _repository.Buscar(produto.Codigo);
            if (produtoDb != null)
            {
                produtoDb.AtualizarDados(produto.Codigo, produto.Descricao, produto.NomeFornecedor, produto.Categoria, produto.PrecoVenda);
                _repository.Atualizar(produtoDb);
            }
            else
            {
                _repository.Cadastrar(produto);
            }
            _uow.CatalogoProdutoUnitOfWork.Commit();
        }

        public CatalogoProduto Deletar(int fornecedorId)
        {
            return _repository.Deletar(fornecedorId);
        }

        List<CatalogoProduto> ICatalogoProdutosAppService.Buscar(CatalogoProdutosSearchDto catalogoProdutoSearchDto)
        {
            return _repository.Buscar(catalogoProdutoSearchDto);
        }
    }
}

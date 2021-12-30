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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CatalogoProdutosAppService(ICatologoProdutosRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            _repository = repository;
            _mapper = mapper;
            _uow = uow;
        }

        public void RegistrarCatalogo(CatalogoProduto produto)
        {
             _repository.Cadastrar(produto);
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

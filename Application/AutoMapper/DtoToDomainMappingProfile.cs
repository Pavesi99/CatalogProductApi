using AutoMapper;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Messaging;

namespace Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CatalogoProdutosDto, CatalogoProduto>();
            CreateMap<CategoriaDto, Categoria>();


        }
    }
}

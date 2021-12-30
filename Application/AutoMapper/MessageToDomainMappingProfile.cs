using AutoMapper;
using Domain.Models;
using Infra.CrossCutting.Dto;
using Messaging;

namespace Application.AutoMapper
{
    public class MessageToDomainMappingProfile : Profile
    {
        public MessageToDomainMappingProfile()
        {
            CreateMap<CatalogoProdutosMessage, CatalogoProduto>();


            //CreateMap<QuantidadeItemProduto, QuantidadeItemProdutoDashDto>();

            //Group
            //CreateMap<QuantidadeItemPacGroup, QuantidadeItemPacDashDto>();
        }
    }
}

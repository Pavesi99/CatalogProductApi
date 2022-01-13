using AutoMapper;
using Domain.Models;
using Messaging;

namespace Application.AutoMapper
{
    public class MessageToDomainMappingProfile : Profile
    {
        public MessageToDomainMappingProfile()
        {
            CreateMap<CatalogoProdutosMessage, CatalogoProduto>();
        }
    }
}

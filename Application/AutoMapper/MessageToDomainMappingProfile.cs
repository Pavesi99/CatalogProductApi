using AutoMapper;
using Domain.Message;
using Domain.Models;

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

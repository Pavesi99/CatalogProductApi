using AutoMapper;

namespace Application.AutoMapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig()
        {
        }
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new MessageToDomainMappingProfile());
            });
        }
    }
}

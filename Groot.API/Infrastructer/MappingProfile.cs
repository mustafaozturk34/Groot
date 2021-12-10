using AutoMapper;

namespace Groot.API.Infrastructer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Groot.Model.User.User, Groot.DB.Entities.User>();
            CreateMap<Groot.DB.Entities.User, Groot.Model.User.User>();
        }
    }
}

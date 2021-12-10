using AutoMapper;

namespace Groot.API.Infrastructer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //for user
            CreateMap<Groot.Model.User.User, Groot.DB.Entities.User>();
            CreateMap<Groot.DB.Entities.User, Groot.Model.User.User>();

            //for product
            CreateMap<Groot.Model.Product.Product, Groot.DB.Entities.Product>();
            CreateMap<Groot.DB.Entities.Product, Groot.Model.Product.Product>();

            //for category
            CreateMap<Groot.Model.Category.Category, Groot.DB.Entities.Category>();
            CreateMap<Groot.DB.Entities.Category, Groot.Model.Category.Category>();
        }
    }
}

using AutoMapper;
using DTO;
using Entities;

namespace MyFirstWebApiSite
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, userLoginDTO>().ReverseMap();
            CreateMap<User, userSaveDTO>().ReverseMap();
            CreateMap<User, userDTO>().ReverseMap();
            CreateMap<Order, orderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Category, categoryDTO>().ReverseMap();
            CreateMap<Product, productDTO>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.CategoryName)).ReverseMap();
        }
    }
}

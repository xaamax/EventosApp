using AutoMapper;
using Eventos.Application.Dtos.Category;
using Eventos.Domain.Entities;

namespace Eventos.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryAddOrEditDTO>().ReverseMap();
            CreateMap<Category, CategoryDeleteDTO>().ReverseMap();
        }
    }
}

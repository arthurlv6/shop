
using AutoMapper;
using Shop.Share;
using System;

namespace Shop.API.Mappers
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryModel>().ReverseMap();
            CreateMap<ProductLink, ProductLinkModel>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.Product.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate?? DateTime.UtcNow))
                .ReverseMap();
        }
    }
}

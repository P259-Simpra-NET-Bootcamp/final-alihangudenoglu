using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.BasketItem;
using Entities.DTOs.Discount;
using Entities.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<User, UserGetDto>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Wallet, WalletDto>();
            CreateMap<WalletDto, Wallet>();

            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<BasketItem, BasketItemDto>();

            CreateMap<DiscountDto, Discount>();
            CreateMap<Discount, DiscountDto>();

            CreateMap<CategoryProduct, Items>();
            CreateMap<Items, CategoryProduct>();



            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}

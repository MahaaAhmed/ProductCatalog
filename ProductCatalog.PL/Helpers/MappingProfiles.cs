using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Product_Catalog.BLL.Dtos;
using Product_Catalog.DAL.Models;
using Product_Catalog.PL.ViewModels;
using System.Collections.Generic;

namespace Product_Catalog.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<SignUpViewModel, ApplicationUser>().ForMember(d=>d.UserName , o=>o.MapFrom(s=>s.FName)).ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
            CreateMap<ApplicationUser, CreateUserViewModel>().ReverseMap();


            CreateMap<RoleViewModel , IdentityRole>()
                .ForMember(d=>d.Name , o=>o.MapFrom(s=>s.RoleName)).ReverseMap();   

        }
    }
}

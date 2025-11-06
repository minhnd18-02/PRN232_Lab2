using AutoMapper;
using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Auths;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Repositories
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<Token, LoginResponse>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, AddCategoryRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
        }
    }
}

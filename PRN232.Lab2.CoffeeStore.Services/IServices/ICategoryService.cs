using PRN232.Lab2.CoffeeStore.Services.ViewModels;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.IServices
{
    public interface ICategoryService
    {
        Task<ServiceResponse<CategoryResponse>> GetCategoryById(int id);
        Task<ServiceResponse<CategoryResponse>> AddCategory(AddCategoryRequest categoryRequest);
        Task<ServiceResponse<CategoryResponse>> UpdateCategory(int id, UpdateCategoryRequest updateCategoryRequest);
        Task<ServiceResponse<int>> DeleteCategory(int id);
        Task<ServiceResponse<PaginationModel<CategoryResponse>>> GetCategoriesPaging(int pageNumber = 1, int pageSize = 5, QueryCategory? queryCategory = null);
    }
}

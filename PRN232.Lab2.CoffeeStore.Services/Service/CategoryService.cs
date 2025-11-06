using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRN232.Lab2.CoffeeStore.Data.Entities;
using PRN232.Lab2.CoffeeStore.Repositories.IRepositories;
using PRN232.Lab2.CoffeeStore.Services.IServices;
using PRN232.Lab2.CoffeeStore.Services.ViewModels;
using PRN232.Lab2.CoffeeStore.Services.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab2.CoffeeStore.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<CategoryResponse>> AddCategory(AddCategoryRequest categoryRequest)
        {
            var response = new ServiceResponse<CategoryResponse>();
            try
            {
                var existing = await _unitOfWork.CategoryRepo.FindEntityAsync(c => c.Name.ToLower() == categoryRequest.Name.ToLower());
                if (existing != null)
                {
                    response.Success = false;
                    response.Error = "Category already exists.";
                    return response;
                }

                var mapCategory = _mapper.Map<Category>(categoryRequest);
                mapCategory.CreatedDate = DateTime.UtcNow;
                
                await _unitOfWork.CategoryRepo.AddAsync(mapCategory);

                response.Success = true;
                response.Message = "Category added successfully.";
                response.Data = _mapper.Map<CategoryResponse>(mapCategory);

            } catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return response;
        }

        public async Task<ServiceResponse<int>> DeleteCategory(int id)
        {
            var response = new ServiceResponse<int>();
            try
            {
                var checkId = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
                if(checkId == null)
                {
                    response.Success = false;
                    response.Message = "CategoryId not found";
                    return response;
                }

                await _unitOfWork.CategoryRepo.RemoveAsync(checkId);

                response.Success = true;
                response.Message = "Category deleted successfully";
                response.Data = id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<PaginationModel<CategoryResponse>>> GetCategoriesPaging(int pageNumber = 1, int pageSize = 5, QueryCategory? queryCategory = null)
        {
            var response = new ServiceResponse<PaginationModel<CategoryResponse>>();

            try
            {
                if (queryCategory != null)
                {
                    var validationContext = new ValidationContext(queryCategory);
                    var validationResults = new List<ValidationResult>();

                    if (!Validator.TryValidateObject(queryCategory, validationContext, validationResults, true))
                    {
                        var errorMessages = validationResults.Select(r => r.ErrorMessage);
                        response.Success = false;
                        response.Message = string.Join("; ", errorMessages);
                        return response;
                    }

                    if (queryCategory.MaxCreatedDate != null &&
                        queryCategory.MinCreatedDate != null &&
                        queryCategory.MaxCreatedDate < queryCategory.MinCreatedDate)
                    {
                        response.Success = false;
                        response.Message = "Invalid range for the queryable Created Date";
                        return response;
                    }
                }

                var query = await FilterCategories(queryCategory);    
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 5;

                var totalRecords = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                var categories = await query
                    .OrderByDescending(c => c.CreatedDate)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var categoryReponse = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

                response.Data = new PaginationModel<CategoryResponse>
                {
                    Page = pageNumber,
                    TotalPage = totalPages,
                    TotalRecords = totalRecords,
                    ListData = categoryReponse
                };

                response.Success = true;
                response.Message = categoryReponse.Any() ? "Retrieve categoryies successfully" : "No category found";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.Message = $"Failed to get categories: {ex.Message}";
                response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return response;
        }

        private async Task<IQueryable<Category>> FilterCategories(QueryCategory? queryCategory)
        {
            var query = _unitOfWork.CategoryRepo.GetAllAsNoTrackingAsQueryable();

            if (queryCategory == null)
                return query;

            if (!string.IsNullOrWhiteSpace(queryCategory.Name))
            {
                query = query.Where(c => c.Name.Contains(queryCategory.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryCategory.Description))
            {
                query = query.Where(c => c.Description.Contains(queryCategory.Description));
            }

            if (queryCategory.MinCreatedDate != null)
            {
                query = query.Where(c => c.CreatedDate >= queryCategory.MinCreatedDate);
            }

            if (queryCategory.MaxCreatedDate != null)
            {
                query = query.Where(c => c.CreatedDate <= queryCategory.MaxCreatedDate);
            }
            return query;
        }

        public async Task<ServiceResponse<CategoryResponse>> GetCategoryById(int id)
        {
            var response = new ServiceResponse<CategoryResponse>();
            try
            {
                var checkId = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
                if (checkId == null)
                {
                    response.Success= false;
                    response.Message = "CategoryId not found";
                    return response;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Retrieve category successfully";
                    response.Data = _mapper.Map<CategoryResponse>(checkId);
                }
            }catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }

        public async Task<ServiceResponse<CategoryResponse>> UpdateCategory(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            var response = new ServiceResponse<CategoryResponse>();
            try
            {
                var checkId = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
                if(checkId == null)
                {
                    response.Success = false;
                    response.Message = "CategoryId not found";
                    return response;
                }
                
                checkId.Name = updateCategoryRequest.Name;
                checkId.Description = updateCategoryRequest.Description;
                checkId.CreatedDate = updateCategoryRequest.CreatedDate;

                await _unitOfWork.CategoryRepo.UpdateAsync(checkId);
                response.Success = true;
                response.Message = "Category updated successfully";
                response.Data = _mapper.Map<CategoryResponse>(checkId);

            } catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.Message;
                response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return response;
        }
    }
}

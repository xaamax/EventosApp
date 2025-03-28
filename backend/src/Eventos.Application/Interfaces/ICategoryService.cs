using Eventos.Application.Dtos.Category;

namespace Eventos.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryAddOrEditDTO dto);
        Task<CategoryDTO[]> GetAllCategorys();
        Task<CategoryDTO> GetCategoryById(int id);
        Task<CategoryDTO> UpdateCategory(int id, CategoryAddOrEditDTO dto);
        Task<CategoryDTO> DeleteCategory(int id, CategoryDeleteDTO dto);
    }
}

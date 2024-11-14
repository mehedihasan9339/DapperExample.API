using DapperExample.API.Dapper;
using DapperExample.API.Models;

namespace DapperExample.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDapper _dapperRepository;

        public CategoryService(IDapper dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var sql = "EXEC sp_GetAllCategories";
            return await _dapperRepository.QueryAsync<Category>(sql);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var sql = "EXEC sp_GetCategoryById @CategoryId";
            return await _dapperRepository.QuerySingleOrDefaultAsync<Category>(sql, new { CategoryId = id });
        }

        public async Task AddCategoryAsync(string name)
        {
            var sql = "EXEC sp_InsertCategory @Name";
            await _dapperRepository.ExecuteAsync(sql, new { Name = name });
        }

        public async Task UpdateCategoryAsync(int id, string name)
        {
            var sql = "EXEC sp_UpdateCategory @CategoryId, @Name";
            await _dapperRepository.ExecuteAsync(sql, new { CategoryId = id, Name = name });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var sql = "EXEC sp_DeleteCategory @CategoryId";
            await _dapperRepository.ExecuteAsync(sql, new { CategoryId = id });
        }
    }
}

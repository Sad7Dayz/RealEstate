using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DataContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// 카테고리 만들기
        /// </summary>
        /// <param name="categoryDto"></param>
        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "Insert into Category (CategoryName, CategoryStatus) values (@categoryName, @categoryStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", categoryDto.CategoryName);
            parameters.Add("@categoryStatus", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        /// <summary>
        /// 카테고리 삭제
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        /// <summary>
        /// 카테고리 리스트
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResultCategoryDto>> GetAllCategory()
        {
            string query = "Select * From Category";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        /// <summary>
        /// 카테고리ID 리스트
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, parameters);
                return values;
            }
        }

        /// <summary>
        /// 카테고리 업데이트
        /// </summary>
        /// <param name="categoryDto"></param>
        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var paramters = new DynamicParameters();
            paramters.Add("@categoryName", categoryDto.CategoryName);
            paramters.Add("@categoryStatus", categoryDto.CategoryStatus);
            paramters.Add("@categoryID", categoryDto.CategoryID);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramters);
            }
        }
    }
}

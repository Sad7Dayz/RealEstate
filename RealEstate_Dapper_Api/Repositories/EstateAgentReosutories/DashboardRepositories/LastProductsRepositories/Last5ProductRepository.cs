using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DataContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentReosutories.DashboardRepositories.LastProductsRepositories
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;
        public Last5ProductRepository(Context context)
        {
            _context= context;
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
        {
            string query = "Select Top(5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate From Product " +
                "inner Join Category On Product.ProductCategory=Category.CategoryID where AppUserId=@employeeId Order by ProductID Desc";
            
            var paramers = new DynamicParameters();
            paramers.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query, paramers);
                return values.ToList();
            }
        }
    }
}

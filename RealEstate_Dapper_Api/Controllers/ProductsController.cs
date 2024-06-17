using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Product리스트
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        /// <summary>
        /// Product리스트와 카테고리
        /// </summary>
        /// <returns></returns>
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
			await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("Advertisement Status Updated");
        }

		[HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
		public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
		{
			await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
			return Ok("Ad Removed from Deals of the Day");
		}

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> GetProductAdvertsListByEmployeeAsyncByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

		[HttpGet("ProductAdvertsListByEmployeeByFalse")]
		public async Task<IActionResult> GetProductAdvertsListByEmployeeAsyncByFalse(int id)
		{
			var values = await _productRepository.GetProductAdvertsListByEmployeeAsyncByFalse(id);
			return Ok(values);
		}

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            {
                await _productRepository.CreateProduct(createProductDto);
                return Ok("Ad successfully added");
            } 
        }

        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var vaules = await _productRepository.GetProductByProductId(id);
            return Ok(vaules);
        }

        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategoryAsync")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

		[HttpGet("GetLast3Product")]
		public async Task<IActionResult> GetLast3Product()
		{
			var values = await _productRepository.GetLast3ProductAsync();
			return Ok(values);
		}
	}
}

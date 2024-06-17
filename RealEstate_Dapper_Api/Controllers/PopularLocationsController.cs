using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopularLocationsController : ControllerBase
	{
		private readonly IPopularLocationRepository _popularLocationRepository;
		public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
		{
			_popularLocationRepository = popularLocationRepository;
		}
		[HttpGet]
		public async Task<IActionResult> PopularLocationList()
		{
			var values = await _popularLocationRepository.GetAllPopularLocation();
			return Ok(values);
		}

		/// <summary>
		/// 서비스 생성
		/// </summary>
		/// <param name="createCategoryDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			await _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);
			return Ok("서비스가 성공적으로 추가 되었습니다.");
		}

		/// <summary>
		/// 서비스 삭제
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePopularLocation(int id)
		{
			await _popularLocationRepository.DeletePopularLocation(id);
			return Ok("서비스가 성공적으로 삭제 되었습니다.");
		}

		/// <summary>
		/// 서비스 업데이트
		/// </summary>
		/// <param name="updateCategoryDto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
		{
			await _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
			return Ok("서비스가 성공적으로 업데이트 되었습니다.");
		}

		/// <summary>
		/// 서비스 리스트
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetPopularLocation(int id)
		{
			var value = await _popularLocationRepository.GetPopularLocation(id);
			return Ok(value);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BottomGridsController : ControllerBase
	{
		private readonly IBottomGridRepository _bottomGridRepository;
		public BottomGridsController(IBottomGridRepository bottomGridRepository)
		{
			_bottomGridRepository = bottomGridRepository;
		}
		[HttpGet]
		public async Task<IActionResult> BottomGridList()
		{
			var values = await _bottomGridRepository.GetAllBottomGrid();
			return Ok(values);
		}

        /// <summary>
        /// BottomGrid 생성
        /// </summary>
        /// <param name="createCategoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("BottomGrid가 성공적으로 추가 되었습니다.");
        }

        /// <summary>
        /// BottomGrid 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("BottomGrid가 성공적으로 삭제 되었습니다.");
        }

        /// <summary>
        /// BottomGrid 업데이트
        /// </summary>
        /// <param name="updateCategoryDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("BottomGrid가 성공적으로 업데이트 되었습니다.");
        }

        /// <summary>
        /// BottomGrid 리스트
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}

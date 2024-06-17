using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreRepository;
        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        /// <summary>
        /// 카테고리 전 리스트
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetail();
            return Ok(values);
        }

        /// <summary>
        /// 카테고리 생성
        /// </summary>
        /// <param name="createCategoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
             await _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("회사소개가 성공적으로 추가 되었습니다.");
        }

        /// <summary>
        /// 카테고리 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            await _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("회사소개 성공적으로 삭제 되었습니다.");
        }

        /// <summary>
        /// 카테고리 업데이트
        /// </summary>
        /// <param name="updateCategoryDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            await _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("카테고리가 성공적으로 업데이트 되었습니다.");
        }

        /// <summary>
        /// 카테고리 리스트
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}

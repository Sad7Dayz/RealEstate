using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		/// <summary>
		/// 카테고리 전 리스트
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var values = await _employeeRepository.GetAllEmployee();
			return Ok(values);
		}

		/// <summary>
		/// 카테고리 생성
		/// </summary>
		/// <param name="createEmployeeDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			await _employeeRepository.CreateEmployee(createEmployeeDto);
			return Ok("Staff 성공적으로 추가 되었습니다.");
		}

		/// <summary>
		/// 카테고리 삭제
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			await _employeeRepository.DeleteEmployee(id);
			return Ok("Staff 성공적으로 삭제 되었습니다.");
		}

		/// <summary>
		/// 카테고리 업데이트
		/// </summary>
		/// <param name="updateCategoryDto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			await _employeeRepository.UpdateEmployee(updateEmployeeDto);
			return Ok("Staff 성공적으로 업데이트 되었습니다.");
		}

		/// <summary>
		/// 카테고리 리스트
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetEmployee(int id)
		{
			var value = await _employeeRepository.GetEmployee(id);
			return Ok(value);
		}
	}
}

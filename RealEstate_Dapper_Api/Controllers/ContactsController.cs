using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : Controller
	{
		private readonly IContactRepository _contactRepository;

		public ContactsController(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		/// <summary>
		/// contact리스트
		/// </summary>
		/// <returns></returns>
		[HttpGet("GetLast4Contact")]
		public async Task<IActionResult> GetLast4Contact()
		{
			var values = await _contactRepository.GetLast4Contact();
			return Ok(values);
		}
	}
}

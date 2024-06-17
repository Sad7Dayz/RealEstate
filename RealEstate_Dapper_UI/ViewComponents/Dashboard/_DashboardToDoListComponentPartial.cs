using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardToDoListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responsMessage = await client.GetAsync("https://localhost:7091/api/ToDoLists");
			if (responsMessage.IsSuccessStatusCode)
			{
				var jsonData = await responsMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}

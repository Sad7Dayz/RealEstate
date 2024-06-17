using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardLast5ProductComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var responsMessage = await client.GetAsync("https://localhost:7091/api/Products/Last5ProductList");
			if (responsMessage.IsSuccessStatusCode)
			{
				var jsonData = await responsMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
				return View(value);
			}
			return View();
		}
    }
}

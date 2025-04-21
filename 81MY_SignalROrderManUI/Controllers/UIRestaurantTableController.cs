using _81MY_SignalROrderManUI.DTOs.RestaurantTableDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace _81MY_SignalROrderManUI.Controllers
{
    public class UIRestaurantTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIRestaurantTableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7183/api/RestaurantTable/ListRestaurantTable");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult GoToMenu(int id)
        {
            TempData["SelectedTableId"] = id;
            return RedirectToAction("Index", "UIMenu");
        }
    }
}

using _81MY_SignalROrderMan.EntityLayer.Entities;
using _81MY_SignalROrderManUI.DTOs.BasketDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace _81MY_SignalROrderManUI.Controllers
{
    public class UIBasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIBasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["TableId"] = id;

            var client = _httpClientFactory.CreateClient();

            var listBasketResponse = await client.GetAsync("https://localhost:7183/api/Basket/ListBasketByRestaurantTable/" + id);

            if (listBasketResponse.IsSuccessStatusCode)
            {
                var listbasketData = await listBasketResponse.Content.ReadAsStringAsync();
                var basketItems = JsonConvert.DeserializeObject<List<ResultBasketDto>>(listbasketData);

                var totalPriceResponse = await client.GetAsync($"https://localhost:7183/api/Basket/GetBasketTotalPriceByRestaurantTableId/" + id);

                if (totalPriceResponse.IsSuccessStatusCode)
                {
                    var totalPriceData = await totalPriceResponse.Content.ReadAsStringAsync();
                    var totalPrice = JsonConvert.DeserializeObject<decimal>(totalPriceData);

                    ViewBag.TotalPrice = totalPrice;
                    decimal tax = 0.08m;
                    ViewBag.Tax = (totalPrice * tax).ToString(".00");
                    ViewBag.TotalPriceWithTax = (totalPrice + totalPrice * tax).ToString(".00");
                }
                return View(basketItems);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7183/api/Basket/DeleteBasket/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = TempData["TableId"] });
            }
            return View();
        }
    }
}

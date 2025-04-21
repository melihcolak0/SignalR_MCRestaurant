using _81MY_SignalROrderMan.DtoLayer.BasketDtos;
using _81MY_SignalROrderManUI.DTOs.BasketDtos;
using _81MY_SignalROrderManUI.DTOs.CategoryDtos;
using _81MY_SignalROrderManUI.DTOs.ProductDtos;
using _81MY_SignalROrderManUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _81MY_SignalROrderManUI.Controllers
{
    public class UIMenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIMenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["SelectedTableId"] != null)
            {
                TempData.Keep("SelectedTableId"); // Aynı request boyunca saklamaya devam eder
                ViewBag.RestaurantTableId = TempData["SelectedTableId"];
            }

            var client = _httpClientFactory.CreateClient();
            
            var responseProducts = await client.GetAsync("https://localhost:7183/api/Product/ListProductWithCategory");            
            var responseCategories = await client.GetAsync("https://localhost:7183/api/Category/ListCategory");

            if (responseProducts.IsSuccessStatusCode && responseCategories.IsSuccessStatusCode)
            {
                var jsonProducts = await responseProducts.Content.ReadAsStringAsync();
                var jsonCategories = await responseCategories.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonProducts);
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonCategories);

                if(products != null && categories != null)
                {
                    var model = new MenuViewModel
                    {
                        Products = products,
                        Categories = categories
                    };
                    return View(model);
                }
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketWithProductIdDto createBasketWithProductIdDto)
        {
            //RestaurantTable'ı dolu yapma
            var client2 = _httpClientFactory.CreateClient();
            StringContent stringContent2 = new StringContent("", Encoding.UTF8, "application/json");
            var responseMessage2 = await client2.
                PutAsync($"https://localhost:7183/api/RestaurantTable/ChangeRestaurantTableStatusToTrue/{createBasketWithProductIdDto.RestaurantTableId}"
                , stringContent2);
            

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketWithProductIdDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7183/api/Basket/CreateBasketWithProductId", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

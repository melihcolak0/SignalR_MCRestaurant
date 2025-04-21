using _81MY_SignalROrderManUI.DTOs.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _81MY_SignalROrderManUI.ViewComponents.UIPanelComponents
{
    public class _UISliderComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UISliderComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7183/api/Slider/ListSlider");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

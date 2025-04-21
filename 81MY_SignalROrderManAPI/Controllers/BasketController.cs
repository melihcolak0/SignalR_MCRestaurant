using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.BasketDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService basketService, IMapper mapper, IProductService productService)
        {
            _basketService = basketService;
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet("ListBasket")]
        public IActionResult ListBasket()
        {
            var values = _mapper.Map<List<ResultBasketDto>>(_basketService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateBasket")]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var value = _mapper.Map<Basket>(createBasketDto);
            _basketService.TAdd(value);

            return Ok("Sepete ürün eklendi!");
        }

        [HttpDelete("DeleteBasket/{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki ürün silindi!");
        }

        [HttpPut("UpdateBasket/{id}")]
        public IActionResult UpdateBasket(int id, UpdateBasketDto updateBasketDto)
        {
            var value = _basketService.TGetById(id);
            _mapper.Map(updateBasketDto, value);
            _basketService.TUpdate(value);
            return Ok("Sepetteki ürün güncellendi!");
        }

        [HttpGet("GetBasket/{id}")]
        public IActionResult GetBasket(int id)
        {
            var value = _basketService.TGetById(id);
            var basket = _mapper.Map<GetBasketDto>(value);
            return Ok(basket);
        }

        [HttpGet("ListBasketByRestaurantTable/{id}")]
        public IActionResult ListBasketByRestaurantTable(int id)
        {
            var values = _mapper.Map<List<ResultBasketDto>>(_basketService.TGetBasketByRestaurantTable(id));
            return Ok(values);
        }

        [HttpPost("CreateBasketWithProductId")]
        public IActionResult CreateBasketWithProductId(CreateBasketWithProductIdDto createBasketWithProductIdDto)
        {
            var product = _productService.TGetById(createBasketWithProductIdDto.ProductId);
            if (product == null)
                return NotFound("Ürün bulunamadı!");

            var basket = _mapper.Map<Basket>(createBasketWithProductIdDto); // ProductId ve RestaurantTableId'yi eşleştirdik.
            basket.Price = product.Price;
            basket.Count = 1;
            basket.TotalPrice = product.Price * basket.Count;
            _basketService.TAdd(basket);

            return Ok("Sepete ürün eklendi!");
        }

        [HttpGet("GetBasketTotalPriceByRestaurantTableId/{restaurantTableId}")]
        public IActionResult GetBasketTotalPriceByRestaurantTableId(int restaurantTableId)
        {
            return Ok(_basketService.TGetBasketTotalPriceByRestaurantTableId(restaurantTableId));
        }
    }
}

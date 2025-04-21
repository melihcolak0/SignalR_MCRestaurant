using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.FeatureDtos;
using _81MY_SignalROrderMan.DtoLayer.ProductDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("ListProduct")]
        public IActionResult ListProduct()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetList());
            return Ok(values);
        }

        [HttpGet("ListProductWithCategory")]
        public IActionResult ListProductWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategoriesDto>>(_productService.TGetProducListWithCategories());
            return Ok(values);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);

            return Ok("Ürün eklendi!");
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün silindi!");
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var value = _productService.TGetById(id);
            _mapper.Map(updateProductDto, value);
            _productService.TUpdate(value);
            return Ok("Ürün güncellendi!");
        }

        [HttpGet("GetProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            var product = _mapper.Map<GetProductDto>(value);
            return Ok(product);
        }

        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

        [HttpGet("GetProductCountByCategoryName/{categoryName}")]
        public IActionResult GetProductCountByCategoryName(string categoryName)
        {
            return Ok(_productService.TGetProductCountByCategoryName(categoryName));
        }

        [HttpGet("GetAvgProductPrice")]
        public IActionResult GetAvgProductPrice()
        {
            return Ok(_productService.TGetAvgProductPrice());
        }

        [HttpGet("GetProductNameByMaxPrice")]
        public IActionResult GetProductNameByMaxPrice()
        {
            return Ok(_productService.TGetProductNameByMaxPrice());
        }

        [HttpGet("GetProductNameByMinPrice")]
        public IActionResult GetProductNameByMinPrice()
        {
            return Ok(_productService.TGetProductNameByMinPrice());
        }

        [HttpGet("GetAvgProductPriceByHamburgers")]
        public IActionResult GetAvgProductPriceByHamburgers()
        {
            return Ok(_productService.TGetAvgProductPriceByHamburgers());
        }

        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            return Ok(_productService.TGetLast9Products());
        }
    }
}

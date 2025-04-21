using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DtoLayer.AboutDtos;
using _81MY_SignalROrderMan.DtoLayer.CategoryDtos;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _81MY_SignalROrderManAPI.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("ListCategory")]
        public IActionResult ListCategory()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetList());
            return Ok(values);
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            // 1. Yöntem
            //_categoryService.TAdd(new Category()
            //{
            //    CategoryName = createCategoryDto.CategoryName,
            //    Status = true
            //});

            // 2. Yöntem
            var value = _mapper.Map<Category>(createCategoryDto);  
            _categoryService.TAdd(value);

            return Ok("Kategori eklendi!");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Kategori silindi!");
        }

        // 1. Yöntem
        //[HttpPut]
        //public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        //{
        //    _categoryService.TUpdate(new Category()
        //    {
        //        CategoryId = updateCategoryDto.CategoryId,
        //        CategoryName = updateCategoryDto.CategoryName,
        //        Status = true
        //    });
        //    return Ok("Kategori güncellendi!");
        //}

        // 2. Yöntem
        [HttpPut("UpdateCategory/{id}")]
        public IActionResult UpdateCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var value = _categoryService.TGetById(id);
            _mapper.Map(updateCategoryDto, value);
            _categoryService.TUpdate(value);
            return Ok("Kategori güncellendi!");
        }

        [HttpGet("GetCategory/{id}")]
        public IActionResult GetCategory(int id)
        {
            // 1. Yöntem
            //var value = _categoryService.TGetById(id);
            //return Ok(value);

            // 2. Yöntem
            var value = _categoryService.TGetById(id);
            var category = _mapper.Map<GetCategoryDto>(value);
            return Ok(category);
        }

        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.TGetCategoryCount());
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.TGetActiveCategoryCount());
        }

        [HttpGet("GetPassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.TGetPassiveCategoryCount());
        }
    }
}

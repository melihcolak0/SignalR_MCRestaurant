using _81MY_SignalROrderManUI.DTOs.CategoryDtos;
using _81MY_SignalROrderManUI.DTOs.ProductDtos;

namespace _81MY_SignalROrderManUI.Models
{
    public class MenuViewModel
    {
        public List<ResultProductDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}

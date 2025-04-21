using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProducListWithCategories();

        public int TGetProductCount();

        public int TGetProductCountByCategoryName(string categoryName);

        public decimal TGetAvgProductPrice();

        public string TGetProductNameByMaxPrice();

        public string TGetProductNameByMinPrice();

        public decimal TGetAvgProductPriceByHamburgers();

        public List<Product> TGetLast9Products();
    }
}

using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public List<Product> GetProducListWithCategories();

        public int GetProductCount();

        public int GetProductCountByCategoryName(string categoryName);

        public decimal GetAvgProductPrice();

        public string GetProductNameByMaxPrice();

        public string GetProductNameByMinPrice();

        public decimal GetAvgProductPriceByHamburgers();

        public List<Product> GetLast9Products();
    }
}

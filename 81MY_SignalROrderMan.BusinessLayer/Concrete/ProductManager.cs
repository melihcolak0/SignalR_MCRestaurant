using _81MY_SignalROrderMan.BusinessLayer.Abstract;
using _81MY_SignalROrderMan.DataAccessLayer.Abstract;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public decimal TGetAvgProductPrice()
        {
            return _productDal.GetAvgProductPrice();
        }

        public decimal TGetAvgProductPriceByHamburgers()
        {
            return _productDal.GetAvgProductPriceByHamburgers();
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetLast9Products()
        {
            return _productDal.GetLast9Products();
        }

        public List<Product> TGetList()
        {
            return _productDal.GetList();
        }

        public List<Product> TGetProducListWithCategories()
        {
            return _productDal.GetProducListWithCategories();
        }

        public int TGetProductCount()
        {
            return _productDal.GetProductCount();
        }

        public int TGetProductCountByCategoryName(string categoryName)
        {
            return _productDal.GetProductCountByCategoryName(categoryName);
        }

        public string TGetProductNameByMaxPrice()
        {
            return _productDal.GetProductNameByMaxPrice();
        }

        public string TGetProductNameByMinPrice()
        {
            return _productDal.GetProductNameByMinPrice();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

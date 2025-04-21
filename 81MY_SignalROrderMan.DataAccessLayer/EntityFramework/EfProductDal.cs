using _81MY_SignalROrderMan.DataAccessLayer.Abstract;
using _81MY_SignalROrderMan.DataAccessLayer.Concrete;
using _81MY_SignalROrderMan.DataAccessLayer.Repositories;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;

        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public decimal GetAvgProductPrice()
        {
            return _context.Products.Average(x => x.Price);
        }

        public decimal GetAvgProductPriceByHamburgers()
        {
            return _context.Products.Where(x => x.Category.CategoryName == "Hamburger").Average(y => y.Price);
        }

        public List<Product> GetLast9Products()
        {
            return _context.Products.OrderByDescending(x => x.ProductId).Take(9).ToList();
        }

        public List<Product> GetProducListWithCategories()
        {
            return _context.Products
                .Include(x => x.Category)
                .ToList();
        }

        public int GetProductCount()
        {
            return _context.Products.Count();
        }

        public int GetProductCountByCategoryName(string categoryName)
        {
            var categoryId = _context.Categories
                .Where(c => c.CategoryName.ToLower() == categoryName.ToLower())
                .Select(c => c.CategoryId)
                .FirstOrDefault();

            return _context.Products.Count(p => p.CategoryId == categoryId);
        }

        public string GetProductNameByMaxPrice()
        {
            return _context.Products
                .OrderByDescending(x => x.Price)
                .Select(y => y.ProductName)
                .FirstOrDefault() ?? "Ürün Bulunamadı!";
        }

        public string GetProductNameByMinPrice()
        {
            return _context.Products
                 .OrderBy(x => x.Price)
                 .Select(y => y.ProductName)
                 .FirstOrDefault() ?? "Ürün Bulunamadı!";
        }
    }
}

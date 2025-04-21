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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        private readonly SignalRContext _context;
        public EfBasketDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Basket> GetBasketByRestaurantTable(int id)
        {
            return _context.Baskets.Include(y => y.Product).Where(x => x.RestaurantTableId == id).ToList();
        }

        public decimal GetBasketTotalPriceByRestaurantTableId(int restaurantTableId)
        {
            return _context.Baskets.Where(x => x.RestaurantTableId == restaurantTableId).Sum(y => y.TotalPrice);
        }
    }
}

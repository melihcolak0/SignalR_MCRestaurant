using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        public List<Basket> GetBasketByRestaurantTable(int id);

        public decimal GetBasketTotalPriceByRestaurantTableId(int restaurantTableId);
    }
}

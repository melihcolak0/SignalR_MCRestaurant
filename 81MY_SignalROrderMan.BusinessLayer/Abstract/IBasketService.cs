using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> TGetBasketByRestaurantTable(int id);

        public decimal TGetBasketTotalPriceByRestaurantTableId(int restaurantTableId);
    }
}

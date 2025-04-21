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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public List<Basket> TGetBasketByRestaurantTable(int id)
        {
            return _basketDal.GetBasketByRestaurantTable(id);
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public List<Basket> TGetList()
        {
            return _basketDal.GetList();
        }

        public void TUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }

        public decimal TGetBasketTotalPriceByRestaurantTableId(int restaurantTableId)
        {
            return _basketDal.GetBasketTotalPriceByRestaurantTableId(restaurantTableId);
        }
    }
}

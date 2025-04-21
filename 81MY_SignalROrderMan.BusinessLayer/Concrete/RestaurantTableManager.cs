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
    public class RestaurantTableManager : IRestaurantTableService
    {
        private readonly IRestaurantTableDal _restaurantTableDal;

        public RestaurantTableManager(IRestaurantTableDal restaurantTableDal)
        {
            _restaurantTableDal = restaurantTableDal;
        }

        public void TAdd(RestaurantTable entity)
        {
            _restaurantTableDal.Add(entity);
        }

        public void TChangeRestaurantTableStatusToFalse(int id)
        {
            _restaurantTableDal.ChangeRestaurantTableStatusToFalse(id);
        }

        public void TChangeRestaurantTableStatusToTrue(int id)
        {
            _restaurantTableDal.ChangeRestaurantTableStatusToTrue(id);
        }

        public void TDelete(RestaurantTable entity)
        {
            _restaurantTableDal.Delete(entity);
        }

        public RestaurantTable TGetById(int id)
        {
            return _restaurantTableDal.GetById(id);
        }

        public List<RestaurantTable> TGetList()
        {
            return _restaurantTableDal.GetList();
        }

        public int TGetRestaurantTableCount()
        {
            return _restaurantTableDal.GetRestaurantTableCount();
        }

        public void TUpdate(RestaurantTable entity)
        {
            _restaurantTableDal.Update(entity);
        }
    }
}

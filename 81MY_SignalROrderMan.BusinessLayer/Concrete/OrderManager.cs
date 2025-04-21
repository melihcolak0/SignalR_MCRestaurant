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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public int TGetActiveOrderCount()
        {
            return _orderDal.GetActiveOrderCount();
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public decimal TGetLastOrderPrice()
        {
            return _orderDal.GetLastOrderPrice();
        }

        public List<Order> TGetList()
        {
            return _orderDal.GetList();
        }

        public int TGetOrderCount()
        {
            return _orderDal.GetOrderCount();
        }

        public decimal TGetTodaysTotalPrice()
        {
            return _orderDal.GetTodaysTotalPrice();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}

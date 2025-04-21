using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        public int TGetOrderCount();

        public int TGetActiveOrderCount();

        public decimal TGetLastOrderPrice();

        public decimal TGetTodaysTotalPrice();
    }
}

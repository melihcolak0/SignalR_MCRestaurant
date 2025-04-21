using _81MY_SignalROrderMan.DataAccessLayer.Abstract;
using _81MY_SignalROrderMan.DataAccessLayer.Concrete;
using _81MY_SignalROrderMan.DataAccessLayer.Repositories;
using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;

        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int GetActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Description == "Müşteri Halen Masada").Count();
        }

        public decimal GetLastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderDate).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public int GetOrderCount()
        {
            return _context.Orders.Count();
        }

        public decimal GetTodaysTotalPrice()
        {
            //return _context.Orders.Where(x => x.OrderDate.Date == DateTime.Now.Date)
            //                       .Sum(y => y.TotalPrice);

            return _context.Orders
                    .Where(x => x.OrderDate >= DateTime.Today && x.OrderDate < DateTime.Today.AddDays(1))
                    .Sum(y => y.TotalPrice);
        }
    }
}

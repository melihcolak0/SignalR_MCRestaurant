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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly SignalRContext _context;
        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public decimal GetMoneyCaseTotalAmount()
        {
            return _context.MoneyCases.Select(x => x.TotalAmount)
                                        .FirstOrDefault();
        }
    }
}

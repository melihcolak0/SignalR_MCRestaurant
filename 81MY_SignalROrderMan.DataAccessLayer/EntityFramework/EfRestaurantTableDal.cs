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
    public class EfRestaurantTableDal : GenericRepository<RestaurantTable>, IRestaurantTableDal
    {
        private readonly SignalRContext _context;
        public EfRestaurantTableDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeRestaurantTableStatusToFalse(int id)
        {
            var value = _context.RestaurantTables.Find(id);
            
            if(value != null)
                value.Status = false;

            _context.SaveChanges();            
        }

        public void ChangeRestaurantTableStatusToTrue(int id)
        {
            var value = _context.RestaurantTables.Find(id);

            if (value != null)
                value.Status = true;

            _context.SaveChanges();
        }

        public int GetRestaurantTableCount()
        {
            return _context.RestaurantTables.Count();
        }
    }
}

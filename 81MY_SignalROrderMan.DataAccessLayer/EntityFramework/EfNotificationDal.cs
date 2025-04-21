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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeNotificationStatus(int id)
        {
            var value = _context.Notifications.Find(id);

            if (value != null)
            {
                value.Status = !value.Status;
                _context.SaveChanges();
            }
        }

        public int GetUnReadNotificationCount()
        {
            return _context.Notifications.Where(x => x.Status == false).Count();
        }

        public List<Notification> ListUnReadNotifications()
        {
            return _context.Notifications.Where(x => x.Status == false).ToList();
        }
    }
}

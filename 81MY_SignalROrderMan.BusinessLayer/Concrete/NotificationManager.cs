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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> TListUnReadNotifications()
        {
            return _notificationDal.ListUnReadNotifications();
        }

        public void TAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void TDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetList();
        }

        public int TGetUnReadNotificationCount()
        {
            return _notificationDal.GetUnReadNotificationCount();
        }

        public void TUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }

        public void TChangeNotificationStatus(int id)
        {
            _notificationDal.ChangeNotificationStatus(id);
        }
    }
}

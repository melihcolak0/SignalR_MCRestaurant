using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        public int TGetUnReadNotificationCount();

        public List<Notification> TListUnReadNotifications();

        public void TChangeNotificationStatus(int id);
    }
}

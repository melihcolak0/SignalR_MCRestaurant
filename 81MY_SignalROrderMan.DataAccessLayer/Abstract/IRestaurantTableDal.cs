using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DataAccessLayer.Abstract
{
    public interface IRestaurantTableDal : IGenericDal<RestaurantTable>
    {
        public int GetRestaurantTableCount();

        public void ChangeRestaurantTableStatusToTrue(int id);

        public void ChangeRestaurantTableStatusToFalse(int id);      
    }
}

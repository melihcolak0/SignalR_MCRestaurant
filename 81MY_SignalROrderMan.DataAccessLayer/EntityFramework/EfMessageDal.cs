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
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EfMessageDal(SignalRContext context) : base(context)
        {
        }
    }
}

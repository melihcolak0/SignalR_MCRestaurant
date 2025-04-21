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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;

        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int GetActiveCategoryCount()
        {
            return _context.Categories.Where(x => x.Status == true).Count();
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }

        public int GetPassiveCategoryCount()
        {
            return _context.Categories.Where(x => x.Status == false).Count();
        }
    }
}

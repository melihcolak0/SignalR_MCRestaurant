using _81MY_SignalROrderMan.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public int TGetCategoryCount();

        public int TGetActiveCategoryCount();

        public int TGetPassiveCategoryCount();
    }
}

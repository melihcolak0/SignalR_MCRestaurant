﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T entity);

        void TDelete(T entity);

        void TUpdate(T entity);

        T TGetById(int id);

        List<T> TGetList();
    }
}

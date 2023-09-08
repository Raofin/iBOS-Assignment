﻿using System.Collections.Generic;

namespace iBOS_Assignment.DAL.Interfaces
{
    public interface IRepo<TClass, TId, TResult>
    {
        List<TClass> Get();

        TClass Get(TId id);

        TResult Add(TClass obj);

        bool Delete(TId id);

        TResult Update(TClass obj);
    }
}

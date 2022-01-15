﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoToo.Repositories
{
    internal interface IRepository <T> where T : class
    {
        event EventHandler<T> OnEntityAdded;
        event EventHandler<T> OnEntityUpdated;
        event EventHandler<T> OnEntityDeleted;

        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}

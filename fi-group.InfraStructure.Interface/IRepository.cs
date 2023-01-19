﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fi_group.InfraStructure.Interface
{
    public interface IRepository<T>
    {
        Task<bool> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(int ID);
        Task<T> GetAsync(int ID);
        Task<IEnumerable<T>> GetAllAsync();
    }
}

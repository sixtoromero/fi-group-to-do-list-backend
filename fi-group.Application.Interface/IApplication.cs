﻿using i_group.Transversal.Common;

namespace fi_group.Application.Interface
{
    public interface IApplication<T>
    {
        Task<Response<bool>> InsertAsync(T modelDto);
        Task<Response<bool>> UpdateAsync(T modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<T>> GetAsync(int ID);
        Task<Response<IEnumerable<T>>> GetAllAsync();
    }
}
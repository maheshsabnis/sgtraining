using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_NewServie.Services
{
    /// <summary>
    /// TEntity: Entity class that will be mapped with Db Table
    /// in: The input parameter for methods declared in interface
    /// TPk: The Primary Key field
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IService<TEntity, in TPk> where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetDataAsync();
        Task<TEntity> GetDataAsync(TPk id);
        Task<TEntity> CreateDataAsync(TEntity entity);
        Task<TEntity> UpdateDataAsync(TPk id, TEntity entity);
        Task<bool> DeleteDataAsync(TPk id);

    }
}

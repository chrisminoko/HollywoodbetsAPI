using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Repository
{
    public interface IRepositoryBase<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int? id);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(int id);
        IQueryable<TEntity> RunStoreProced(string StoreProcedure);
    }
}

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
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> RunStoreProced(string StoreProcedure);
    }
}

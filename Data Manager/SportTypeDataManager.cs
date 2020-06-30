using Microsoft.EntityFrameworkCore;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Data_Manager
{
    public class SportTypeDataManager : ISportType
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public SportTypeDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }
        public void Add(SportTypes entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SportTypes entity)
        {
            throw new NotImplementedException();
        }

        public SportTypes Get(int id)
        {
            var SportTypes = _hollywoodbetsDBContext.SportTypes.
                SingleOrDefault(x => x.SportId == id);

            return SportTypes;

        }

        public IEnumerable<SportTypes> GetAll()
        {
            try
            {
                string proc = "[dbo].[GetSportTypes]";
                return RunStoreProced(proc);
            }
            catch (Exception )
            {

                throw;
            }
        }

        public IQueryable<SportTypes> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.SportTypes.FromSqlRaw(StoreProcedure);
        }

        public void Update(SportTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}

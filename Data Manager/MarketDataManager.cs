using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportAPISever.Data_Manager
{
    public class MarketDataManager:IMarket
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public MarketDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public void Add(Market entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Market entity)
        {
            throw new NotImplementedException();
        }

        public Market Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Market> GetAll()
        {
            try
            {
                string storeProc = "[dbo].[GetAllMarkts]";
                return RunStoreProced(storeProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Market> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Market.FromSqlRaw(StoreProcedure);
        }

        public void Update(Market entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class CountryDataManager:ICountry
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public CountryDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public void Add(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public Country Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Country> GetSportCountry(int? sportid)
        {
            try
            {
                string proc = $"[dbo].[GetSportCountry]@SportId={sportid}";
                return RunStoreProced(proc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Country> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Country.FromSqlRaw(StoreProcedure);
        }

        public void Update(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}

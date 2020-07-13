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
    public class TournamentDataManager:ITournament
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public TournamentDataManager(HollywoodbetsDBContext  hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Tournament Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tournament> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tournament> GetTournamentBasedOnCountries(int? id)
        {
            try
            {
                string proc = $"[dbo].[GetCountryTournament]@CountryId={id}";
                return RunStoreProced(proc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Tournament> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Tournament.FromSqlRaw(StoreProcedure);
        }

        public int Update(Tournament entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class BetTypeDataManager:IBetType
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public BetTypeDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public void Add(BetTypes entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BetTypes entity)
        {
            throw new NotImplementedException();
        }

        public BetTypes Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetTypes> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetTypes> GetEventTournament(int? TournamentId)
        {
            try
            {
                string StorProc = $"[dbo].[TournamentBetType]@TournamentID={TournamentId}";
                return RunStoreProced(StorProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<BetTypes> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.BetTypes.FromSqlRaw(StoreProcedure);
        }

        public void Update(BetTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}

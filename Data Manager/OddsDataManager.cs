using Microsoft.EntityFrameworkCore;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Data_Manager
{
    public class OddsDataManager: IOddsDetails
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public OddsDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public void Add(OddsDetails entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OddsDetails entity)
        {
            throw new NotImplementedException();
        }

        public OddsDetails Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OddsDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<OddsDetails> GetOddsDetails(int? tournamentID)
        {

            try
            {
                string proc = $"[dbo].[OddsBasedOnTournament]@TournamentID={tournamentID}";
                return RunStoreProced(proc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<OddsDetails> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.OddsDetails.FromSqlRaw(StoreProcedure);
        }

        public void Update(OddsDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}

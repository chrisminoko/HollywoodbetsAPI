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
    public class EventMarketType:IEventMarket
    {

        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public EventMarketType(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(BetEventsDetails entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BetEventsDetails Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetEventsDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BetEventsDetails> GetEventsDetails(int? tournamentID)
        {

            try
            {
                string proc = $"[dbo].[EventMarkets]@tournamentID={tournamentID}";
                return RunStoreProced(proc);
            }
            catch (Exception)
            {

                throw;
            }


        }


        public IQueryable<BetEventsDetails> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.EventsDetails.FromSqlRaw(StoreProcedure);
        }

        public int Update(BetEventsDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}

using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportAPISever.Model.View_Models;

namespace SportAPISever.Data_Manager
{
    public class EventsDataManager : IEvents
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public EventsDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }
        public void Add(Events entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Events entity)
        {
            throw new NotImplementedException();
        }

        public Events Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Events> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetEventsDetails> GetBetEvents(int? TournamentId)
        {
            try
            {
                string storProc = $"[dbo].[GetEvenDetails]@TournamentID={TournamentId}";
                return RunStorePro(storProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Events> GetTournamentEventsByID(int ? TournamentId)
        {
            try
            {
                string StorProc = $"[dbo].[GetTournamentEventsByTournamentId]@TournamentID={TournamentId}";
                return RunStoreProced(StorProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<BetEventsDetails> RunStorePro(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.EventsDetails.FromSqlRaw(StoreProcedure);
        }

        public IQueryable<Events> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Events.FromSqlRaw(StoreProcedure);
        }

        public void Update(Events entity)
        {
            throw new NotImplementedException();
        }

   
    }
}

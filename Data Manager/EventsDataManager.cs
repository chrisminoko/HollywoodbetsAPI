using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportAPISever.Model.View_Models;
using System.Data;
using Dapper;

namespace SportAPISever.Data_Manager
{
    public class EventsDataManager : IEvents
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public EventsDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }
        public int Add(Events entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TournamentId", entity.TournamentId);
                parameters.Add("@EventName", entity.EventName);
                parameters.Add("@EvebtDate", entity.EventDate);
                rowAffected = connection.Execute("AddEvent", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE Events WHERE  EventId=@Id", parameter);
                return affectedRows;
            }

        }

        public IEnumerable<DisplayEvents> DisplayEvents()
        {
            var sql = "EXEC  ShowEvent";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<DisplayEvents>(sql);
                return result.ToList();
            }
        }

        public Events Get(int? id)
        {
            var sql = "SELECT * FROM Events WHERE  EventId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Events>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Events> GetAll()
        {
            var sql = "SELECT * FROM Events";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Events>(sql);
                return result.ToList();
            }
        }

        public IEnumerable<BetEventsDetails> GetBetEvents(int? TournamentId)
        {
            try
            {

                return null;

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
          
            throw new NotImplementedException();
        }

        public IQueryable<Events> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Events.FromSqlRaw(StoreProcedure);
        }

        public int Update(Events entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EventID", entity.EventId);
                parameters.Add("@TournamentId", entity.TournamentId);
                parameters.Add("@EventName", entity.EventName);
                parameters.Add("@EvebtDate", entity.EventDate);
                rowAffected = connection.Execute("UpdateEvents", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

   
    }
}

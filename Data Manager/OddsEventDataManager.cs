using Dapper;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using SportAPISever.Model.View_Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Data_Manager
{
    public class OddsEventDataManager : IOddsEvents
    {
        public int Add(OddsEvents entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EventId", entity.EventsId);
                parameters.Add("@MarketID", entity.MarketID);
                parameters.Add("@Odds", entity.Odds);
                rowAffected = connection.Execute("AddOdds", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE Odds WHERE  OddsId=@Id", parameter);
                return affectedRows;
            }
        }

        public OddsEvents Get(int? id)
        {
            var sql = "SELECT * FROM Odds WHERE  Id=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<OddsEvents>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<OddsEvents> GetAll()
        {
            var sql = "SELECT * FROM Odds";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<OddsEvents>(sql);
                return result.ToList();
            }
        }

        public IEnumerable<OddEvent> GetOddsEvents()
        {
            var sql = "EXEC  DisplayOdds";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<OddEvent>(sql);
                return result.ToList();
            }
        }

        public IQueryable<OddsEvents> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(OddsEvents entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarketID", entity.MarketID);
                parameters.Add("@EventID", entity.EventsId);
                parameters.Add("@TournamentId", entity.Odds);
                rowAffected = connection.Execute("UpdateOddsEvents", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

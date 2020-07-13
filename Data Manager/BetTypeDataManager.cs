using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

namespace SportAPISever.Data_Manager
{
    public class BetTypeDataManager:IBetType
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public BetTypeDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(BetTypes entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BetType", entity.Bettype);
                rowAffected = connection.Execute("AddBettype", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;

        }

        public int Delete(int id)
        {
            
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE BetTypes WHERE  betypeid=@Id", parameter);
                return affectedRows ;
            }

            
        }

        public BetTypes Get(int? id)
        {

            var sql = "SELECT * FROM BetTypes WHERE  betypeid=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BetTypes>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<BetTypes> GetAll()
        {
            var sql = "SELECT * FROM BetTypes";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BetTypes>(sql);
                return result.ToList();
            }
        }
        // Need to Migrate this to dapper
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

        public int Update(BetTypes entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Betypeid", entity.Betypeid);
                parameters.Add("@bettype", entity.Bettype);
                rowAffected = connection.Execute("UpdateBetType", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

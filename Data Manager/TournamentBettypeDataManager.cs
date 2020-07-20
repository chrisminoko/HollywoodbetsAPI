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
    public class TournamentBettypeDataManager : ITournamentBettype
    {
      
        public int Add(TournamentBeTypes entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TournamentId", entity.TournamentId);
                parameters.Add("@TournamentBetypeID", entity.TournamentBetypeID);
                rowAffected = connection.Execute("AddTournamentBettype", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE TournamentBeTypes WHERE  Id=@Id", parameter);
                return affectedRows;
            }
        }

        public TournamentBeTypes Get(int? id)
        {
            {
                var sql = "SELECT * FROM TournamentBeTypes WHERE  Id=@Id";
                using (var connection = DbService.sqlConnection())
                {
                    connection.Open();
                    var result = connection.Query<TournamentBeTypes>(sql, new { Id = id });
                    return result.FirstOrDefault();
                }
            }


        }
        public IEnumerable<TournamentBeTypes> GetAll()
        {

            throw new NotImplementedException();
        }

        public IEnumerable<TournamentBettype> GetTournamentBettypes()
        {
            var sql = "EXEC  DisplayTournamentBetTypes";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<TournamentBettype>(sql);
                return result.ToList();
            }
        }

        public IQueryable<TournamentBeTypes> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(TournamentBeTypes entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TournamentBetypeID", entity.TournamentBetypeID);
                parameters.Add("@TournamentId", entity.TournamentId);
                rowAffected = connection.Execute("UpdateTournamentBeTypes", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}
    


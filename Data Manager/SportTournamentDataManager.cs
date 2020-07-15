using Dapper;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Data_Manager
{
    public class SportTournamentDataManager : ISportTournament
    {
        public int Add(SportTournament entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SportId", entity.SportId);
                parameters.Add("@CountryId", entity.CountryId);
                parameters.Add("@TournamentId", entity.SportTournamentId);
                rowAffected = connection.Execute("AddSportTournament", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE SportTournament WHERE  SportTournamentId=@Id", parameter);
                return affectedRows;
            }
        }

        public SportTournament Get(int? id)
        {
            var sql = "SELECT * FROM SportTournament WHERE  SportTournamentId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<SportTournament>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<SportTournament> GetAll()
        {
            var sql = "SELECT * FROM SportTournament";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<SportTournament>(sql);
                return result.ToList();
            }
        }

        public IQueryable<SportTournament> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(SportTournament entity)
        {
            throw new NotImplementedException();
        }
    }
}

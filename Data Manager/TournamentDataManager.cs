using Dapper;
using Microsoft.EntityFrameworkCore;
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
    public class TournamentDataManager:ITournament
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public TournamentDataManager(HollywoodbetsDBContext  hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(Tournament entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@name", entity.Name);
                rowAffected = connection.Execute("AddTournament", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE Tournament WHERE  TournamentID=@Id", parameter);
                return affectedRows;
            }
        }

        public Tournament Get(int? id)
        {
            var sql = "SELECT * FROM Tournament WHERE  TournamentID=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Tournament>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Tournament> GetAll()
        {
            var sql = "SELECT * FROM Tournament";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Tournament>(sql);
                return result.ToList();
            }
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
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TournamentID", entity.TournamentId);
                parameters.Add("@name", entity.Name);
                rowAffected = connection.Execute("UpdateTournament", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

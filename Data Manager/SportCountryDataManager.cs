using Dapper;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using SportAPISever.Model.View_Models;
using SportAPISever.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Data_Manager
{
    public class SportCountryDataManager : ISportCountry
    {
     
        public int Add(SportCountry entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SportId", entity.SportId);
                parameters.Add("@CountryId", entity.CountryId);
                rowAffected = connection.Execute("InSertSportCountry", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE sportCountry WHERE  SportCountryId=@Id", parameter);
                return affectedRows;
            }
        }

        public SportCountry Get(int? id)
        {
            var sql = "SELECT * FROM sportCountry WHERE  SportCountryId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<SportCountry>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<SportCountry> GetAll()
        {
            var sql = "SELECT * FROM sportCountry";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<SportCountry>(sql);
                return result.ToList();
            }
        }

        public IEnumerable<ShowSportCountry> GetSportCountry()
        {
            var sql = "EXEC  ShowSportCountry";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<ShowSportCountry>(sql);
                return result.ToList();
            }

        }

        public IQueryable<SportCountry> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(SportCountry entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class CountryDataManager:ICountry
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public CountryDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(Country entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Flagurl", entity.Flagurl);
                rowAffected = connection.Execute("AddCountry", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {

            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE Country WHERE  Countryid=@Id", parameter);
                return affectedRows;
            }
        }

        public Country Get(int? id)
        {
            var sql = "SELECT * FROM Country WHERE  Countryid=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Country>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Country> GetAll()
        {
            var sql = "SELECT * FROM Country";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Country>(sql);
                return result.ToList();
            }
        }

        public IQueryable<Country> GetSportCountry(int? sportid)
        {
            try
            {
                string proc = $"[dbo].[GetSportCountry]@SportId={sportid}";
                return RunStoreProced(proc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Country> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Country.FromSqlRaw(StoreProcedure);
        }

        public int Update(Country entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Countryid", entity.Countryid);
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Flagurl", entity.Flagurl);
                rowAffected = connection.Execute("UpdateCountry", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

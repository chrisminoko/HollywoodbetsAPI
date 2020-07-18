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
    public class MarketDataManager:IMarket
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public MarketDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(Market entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarketName", entity.MarkeType);
                rowAffected = connection.Execute("AddMarket", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE Market WHERE  MarketId=@Id", parameter);
                return affectedRows;
            }
        }

        public Market Get(int? id)
        {
            var sql = "SELECT * FROM Market WHERE  MarketId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<Market>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<Market> GetAll()
        {
            try
            {
                string storeProc = "[dbo].[GetAllMarkts]";
                return RunStoreProced(storeProc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Market> RunStoreProced(string StoreProcedure)
        {
            return _hollywoodbetsDBContext.Market.FromSqlRaw(StoreProcedure);
        }

        public int Update(Market entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarketId", entity.MarketId);
                parameters.Add("@MarketName", entity.MarkeType);
                rowAffected = connection.Execute("UpdateMarket", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

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
    public class BettyepeMarketsDataManager : IBettyepeMarkets
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public BettyepeMarketsDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(BettyepeMarkets entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@bettypeId", entity.BetTypeId);
                parameters.Add("@marketId", entity.BetypeMarketId);
                rowAffected = connection.Execute("AddBettypeMarket", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE BettyepeMarkets WHERE  BetTypeMarketID=@Id", parameter);
                return affectedRows;
            }
        }

        public BettyepeMarkets Get(int? id)
        {
            var sql = "SELECT * FROM BettyepeMarkets WHERE  BetTypeMarketID=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BettyepeMarkets>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<BettyepeMarkets> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetypeMarketDetail> GetBetypeMarkets()
        {
            var sql = "EXEC  ShowBetTypeMarket";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BetypeMarketDetail>(sql);
                return result.ToList();
            }

        }

        public IQueryable<BettyepeMarkets> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(BettyepeMarkets entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@bettypeId", entity.BetTypeId);
                parameters.Add("@marketId", entity.BetypeMarketId);
                rowAffected = connection.Execute("UpdateBettypeMarket", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

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
    public class BetSlipDataManager : IBetSlip
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public BetSlipDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(BetSlip entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@odds", entity.Odds);
                parameters.Add("@StakeAmount", entity.StakeAmount);
                parameters.Add("@UserAccount", entity.UserAccount);
                rowAffected = connection.Execute("AddBetSlip", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE BetSlipTbl WHERE  BetSlipID=@Id", parameter);
                return affectedRows;
            }
        }

        public BetSlip Get(int? id)
        {
            var sql = "SELECT * FROM BetSlipTbl WHERE  BetSlipID=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BetSlip>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<BetSlip> GetAll()
        {
            try
            {


                using (var connection = DbService.sqlConnection())
                {
                    var result = connection.Query<BetSlip>("Execute GetBetSlip");
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<BetSlip> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(BetSlip entity)
        {
            throw new NotImplementedException();
        }
    }
}

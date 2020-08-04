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
    public class BetItermDataManager: IBetIterm
    {
        private readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public BetItermDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }

        public int Add(BetIterm entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BetSlipId", entity.BetSlipId);
                parameters.Add("@SportID", entity.SportId);
                parameters.Add("@BetTypeId", entity.BetTypeId);
                parameters.Add("@EventID", entity.EventId);
                parameters.Add("@MarketID", entity.MarketId);
                parameters.Add("@Date", entity.Date);
                parameters.Add("@TicketNumber", entity.TicketNumber);
                parameters.Add("@Status", entity.Status);
                rowAffected = connection.Execute("AddBetSlipIterm", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

        public int Delete(int id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE BetItermTbl WHERE  BetId=@Id", parameter);
                return affectedRows;
            }
        }

        public BetIterm Get(int? id)
        {
            var sql = "SELECT * FROM BetItermTbl WHERE  BetId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<BetIterm>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<BetIterm> GetAll()
        {
            try
            {


                using (var connection = DbService.sqlConnection())
                {
                    var result = connection.Query<BetIterm>("Execute GetBetIterm");
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<BetIterm> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(BetIterm entity)
        {
            throw new NotImplementedException();
        }
    }
}

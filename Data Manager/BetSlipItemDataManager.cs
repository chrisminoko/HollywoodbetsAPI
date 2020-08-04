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
    public class BetSlipItemDataManager : IBetSlipItem
    {
        public int Add(BetSlipIterm entity)
        {
            int rowAffected = 0;
            DynamicParameters parameter = new DynamicParameters();

            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@odds", entity.BetSlip.Odds);
                parameters.Add("@StakeAmount", entity.BetSlip.StakeAmount);
                parameters.Add("@UserAccount", entity.BetSlip.UserAccount);
                rowAffected = connection.Execute("AddBetSlip", parameters, commandType: CommandType.StoredProcedure);
                foreach (var item in entity.BetIterm)
                {

                    parameter.Add("@BetSlipId", item.BetSlipId);
                    parameter.Add("@SportID", item.SportId);
                    parameter.Add("@BetTypeId", item.BetTypeId);
                    parameter.Add("@EventID", item.EventId);
                    parameter.Add("@MarketID", item.MarketId);
                    parameter.Add("@Date", item.Date);
                    parameter.Add("@TicketNumber", item.TicketNumber);
                    parameter.Add("@Status", item.Status);
                    rowAffected+= connection.Execute("AddBetSlipIterm", parameter, commandType: CommandType.StoredProcedure);
                }
                    return rowAffected;
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BetSlipIterm Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BetSlipIterm> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BetSlipIterm> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(BetSlipIterm entity)
        {
            throw new NotImplementedException();
        }
    }
}

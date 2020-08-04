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
            foreach (var item in entity.BetIterms)
            {
                using (var connection = DbService.sqlConnection())
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@BetSlipId", item.BetSlipId);
                    parameters.Add("@SportID", item.SportId);
                    parameters.Add("@BetTypeId", item.BetTypeId);
                    parameters.Add("@EventID", item.EventId);
                    parameters.Add("@MarketID", item.MarketId);
                    parameters.Add("@Date", item.Date);
                    parameters.Add("@TicketNumber", item.TicketNumber);
                    parameters.Add("@Status", item.Status);
                    rowAffected = connection.Execute("AddBetSlipIterm", parameters, commandType: CommandType.StoredProcedure);
                }

                return rowAffected;
            }
            
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@odds", entity.BetSlip.odds);
                parameters.Add("@StakeAmount", entity.BetSlip.StakeAmount);
                parameters.Add("@UserAccount", entity.BetSlip.UserAccount);
                rowAffected = connection.Execute("AddBetSlip", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
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

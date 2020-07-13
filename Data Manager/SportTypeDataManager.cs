using Microsoft.EntityFrameworkCore;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace SportAPISever.Data_Manager
{
    public class SportTypeDataManager : ISportType
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public SportTypeDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }
        public int Add(SportTypes entity)
        {


            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Imageurl", entity.Imageurl);
                rowAffected = connection.Execute("AddSportType", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;

        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSportTree(int? id)
        {
            using (var connection = DbService.sqlConnection())
            {
                var parameter = new { Id = id };
                var affectedRows = connection.Execute("DELETE sportTypes WHERE sportId =@Id",parameter);
                return affectedRows > 0;
            }
        }

        public  SportTypes Get(int? id)
        {
         
            var sql = "SELECT * FROM sportTypes WHERE  sportId=@Id";
            using (var connection = DbService.sqlConnection())
            {
                connection.Open();
                var result = connection.Query<SportTypes>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }

        public IEnumerable<SportTypes> GetAll()
        {
            try
            {
                

                using (var connection = DbService.sqlConnection()) 
                {
                    var result = connection.Query<SportTypes>("Execute GetSportTypes");
                    return result;
                }
            }
            catch (Exception ex )
            {
                throw ex;
            }
        }

        public IQueryable<SportTypes> RunStoreProced(string StoreProcedure)
        {
            throw new NotImplementedException();
        }

        public int Update(SportTypes entity)
        {
            int rowAffected = 0;
            using (var connection = DbService.sqlConnection())
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SportId", entity.SportId);
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Imageurl", entity.Imageurl);
                rowAffected = connection.Execute("UpdateCountry", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }
    }
}

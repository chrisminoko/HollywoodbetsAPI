using Microsoft.EntityFrameworkCore;
using SportAPISever.Context;
using SportAPISever.Contracts;
using SportAPISever.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SportAPISever.Data_Manager
{
    public class SportTypeDataManager : ISportType
    {
        readonly HollywoodbetsDBContext _hollywoodbetsDBContext;
        public SportTypeDataManager(HollywoodbetsDBContext hollywoodbetsDBContext)
        {
            _hollywoodbetsDBContext = hollywoodbetsDBContext;
        }
        public void Add(SportTypes entity)
        {

            using (var connection = DbService.sqlConnection()) 
            {
                var result = connection.Execute($"EXECUTE dbo.AddtSportTypes{entity.Name},{entity.Imageurl}");
            }
            
        }

        public void Delete(SportTypes entity)
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
         
            var sql = "SELECT * FROM sportTypes WHERE  sportId =@Id";
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
                DeleteSportTree(1);

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

        public void Update(SportTypes entity)
        {
            using (var connection = DbService.sqlConnection()) 
            {
                var results = connection.Execute($"Execute dbo.UpdateSportType{entity.SportId},{entity.Name},{entity.Imageurl}");
            }
        }
    }
}

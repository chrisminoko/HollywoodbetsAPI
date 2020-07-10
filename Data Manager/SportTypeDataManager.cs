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
            _hollywoodbetsDBContext.Add(entity);
            _hollywoodbetsDBContext.SaveChanges();
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

        public SportTypes Get(int id)
        {
            var SportTypes = _hollywoodbetsDBContext.SportTypes.
                SingleOrDefault(x => x.SportId == id);

            return SportTypes;

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
            return _hollywoodbetsDBContext.SportTypes.FromSqlRaw(StoreProcedure);
        }

        public void Update(SportTypes entity)
        {
            throw new NotImplementedException();
        }
    }
}

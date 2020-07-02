using SportAPISever.Model;
using SportAPISever.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Contracts
{
   public interface IEvents:IRepositoryBase<Events>
    {
        IEnumerable<Events> GetTournamentEventsByID(int ? TournamentId);
        IEnumerable<>
    }
}

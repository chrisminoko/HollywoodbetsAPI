using SportAPISever.Model;
using SportAPISever.Model.View_Models;
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
        IEnumerable<BetEventsDetails> GetBetEvents(int? TournamentId);
        IEnumerable<BetEventsDetails> RunStorePro(string StoreProcedure);
        IEnumerable<DisplayEvents> DisplayEvents();

    }
}

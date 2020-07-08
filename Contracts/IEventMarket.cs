using SportAPISever.Model.View_Models;
using SportAPISever.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Contracts
{
    public interface IEventMarket :IRepositoryBase<BetEventsDetails>
    {
        IQueryable<BetEventsDetails> GetEventsDetails(int ? id);
    }
}

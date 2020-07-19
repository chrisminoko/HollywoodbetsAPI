using System;
using System.Collections.Generic;

namespace SportAPISever.Model
{
    public partial class BettyepeMarkets
    {
        public int BetTypeMarketID { get; set; }
        public int? BetypeMarketId { get; set; }
        public int? BetTypeId { get; set; }

        public virtual BetTypes BetType { get; set; }
        public virtual Market BetypeMarket { get; set; }
    }
}

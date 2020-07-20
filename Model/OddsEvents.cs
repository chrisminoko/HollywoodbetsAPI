using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model
{
    public class OddsEvents
    {
        public int OddsId { get; set; }
        public decimal Odds { get; set; }
        public int EventsId { get; set; }
        public int MarketID { get; set; }
    }
}

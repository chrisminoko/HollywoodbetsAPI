using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class DisplayEvents
    {
        public int EventId { get; set; }
        public string TournamentName { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace SportAPISever.Model
{
    public partial class Events
    {
        public int EventId { get; set; }
        public int? TournamentId { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
    }
}

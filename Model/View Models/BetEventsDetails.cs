using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class BetEventsDetails
    {
        [Key]
        public int TournamentId { get; set; }
        public string EventName { get; set; }
        public string MarkeType { get; set; }
        public decimal Odds { get; set; }
        public DateTime EventDate { get; set; }
        public string flagurl { get; set; }
    }
}

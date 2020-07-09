using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class OddsDetails
    {
        [Key]
        public int OddsId { get; set; }
        public int TournamentId { get; set; }
        public int MarketID { get; set; }
        public int EventId { get; set; }
        public decimal ODDS { get; set; }
        public string MarkeType { get; set; }
        public int TournamentBetypeID { get; set; }
    }
}

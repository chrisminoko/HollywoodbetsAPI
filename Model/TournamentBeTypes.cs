using System;
using System.Collections.Generic;

namespace SportAPISever.Model
{
    public partial class TournamentBeTypes
    {
        public int Id { get; set; }
        public int? TournamentId { get; set; }
        public int? TournamentBetypeID { get; set; }
    }
}

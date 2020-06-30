using System;
using System.Collections.Generic;

namespace SportAPISever.Model
{
    public partial class SportTournament
    {
        public int? TournamentId { get; set; }
        public int? SportId { get; set; }
        public int? CountryId { get; set; }
    }
}

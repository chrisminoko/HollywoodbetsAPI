using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportAPISever.Model
{
    public partial class SportTournament
    {
        [Key]
        public int SportTournamentId { get; set; }
        public int? TournamentId { get; set; }
        public int? SportId { get; set; }
        public int? CountryId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class BetEventsDetails
    {
        [Key]
      
        public int TournamentID { get; set; }
        public int EventId { get; set; }
        public int BetTypeID { get; set; }
        public int MarketId { get; set; }
        public string MarkeType { get; set; }
        public decimal Odds { get; set; }
      


    }
}

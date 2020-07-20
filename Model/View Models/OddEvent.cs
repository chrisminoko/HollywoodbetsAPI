using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class OddEvent
    {
        public int OddsId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string MarkeType { get; set; }
        public decimal Odds { get; set; }
    }
}

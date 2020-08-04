using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model
{
    public class BetIterm
    {
        [Key]
        public int BetId { get; set; }
        public int BetSlipId { get; set; }
        public int SportId { get; set; }
        public int EventId { get; set; }
        public int BetTypeId { get; set; }
        public int MarketId { get; set; }
        public int TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

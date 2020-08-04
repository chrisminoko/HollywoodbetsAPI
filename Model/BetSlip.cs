using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model
{
    public class BetSlip
    {
        [Key]
        public int BetSlipID { get; set; }
        public decimal StakeAmount { get; set; }
        public decimal odds { get; set; }
        public int UserAccount { get; set; }
    }
}

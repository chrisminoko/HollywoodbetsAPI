using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model
{
    public class BetSlipIterm
    {
        public BetIterm [] BetIterms { get; set; }
        public BetSlip  BetSlip { get; set; }
    }
}

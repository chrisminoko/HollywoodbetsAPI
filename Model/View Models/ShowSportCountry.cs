using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Model.View_Models
{
    public class ShowSportCountry
    {
        public int SportCountryId { get; set; }
        public string Countryname { get; set; }
        public string Sportname { get; set; }
        public string Imageurl { get; set; }
        public string Flagurl { get; set; }
    }
}

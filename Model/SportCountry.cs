using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportAPISever.Model
{
    public partial class SportCountry
    {
        [Key]
        public int SportCountryId { get; set; }
        public int? SportId { get; set; }
        public int? CountryId { get; set; }
    }
}

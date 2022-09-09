using System;
using System.Collections.Generic;

namespace Docker.Core.Entities
{
    public partial class Seller
    {
        public int CodeSeller { get; set; }
        public string? NameSeller { get; set; }
        public string? LastNameSeller { get; set; }
        public string? DocumentSeller { get; set; }
        public int? CodeCitySeller { get; set; }

        public virtual City? CodeCitySellerNavigation { get; set; }
    }
}

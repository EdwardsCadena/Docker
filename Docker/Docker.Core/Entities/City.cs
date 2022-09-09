using System;
using System.Collections.Generic;

namespace Docker.Core.Entities
{
    public partial class City
    {
        public City()
        {
            Sellers = new HashSet<Seller>();
        }

        public int CodeCity { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
    }
}

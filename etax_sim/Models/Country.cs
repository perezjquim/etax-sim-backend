using System;
using System.Collections.Generic;

namespace etax_sim.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<Region> Regions { get; set; }        
    }
}
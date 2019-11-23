using System;
namespace etax_sim.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }        

        public int CountryId { get; set; }
	public Country Country { get; set; }        
    }
}
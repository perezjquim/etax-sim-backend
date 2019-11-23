using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("SimulationLog")]
    public class SimulationLog
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("ModifiedAt")]
        public DateTime ModifiedAt { get; set; }        

        [Column("RegionId")]
        public int RegionId { get; set; }
        public Region Region { get; set; }        

        [Column("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }           

        // TODO - SIMULATION TYPE 

        public ICollection<SimulationLogParam> Params { get; set; }        
    }
}
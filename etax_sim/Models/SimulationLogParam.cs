using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("SimulationLogParam")]
    public class SimulationLogParam
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ParamName")]
        public string ParamName { get; set; }

        [Column("ParamValue")]        
        public string ParamValue { get; set; }

        [Column("IsInput")]        
        public bool IsInput { get; set; }

        [Column("CreatedAt")]        
        public DateTime CreatedAt { get; set; }

        [Column("ModifiedAt")]        
        public DateTime ModifiedAt { get; set; }        

        [Column("SimulationLogId")]
        public int SimulationLogId { get; set; }
        public SimulationLog SimulationLog { get; set; }
    }
}
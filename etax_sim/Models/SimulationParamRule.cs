using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("SimulationParamRule")]
    public class SimulationParamRule
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("ParamName")] public String ParamName { get; set; }

        [Column("MinValue")] public double MinValue { get; set; }

        [Column("MaxValue")] public double MaxValue { get; set; }

    }
}
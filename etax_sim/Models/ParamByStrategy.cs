using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("ParamByStrategy")]
    public class ParamByStrategy
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("StrategyId")] public String StrategyId { get; set; }

        [Column("SimulationParamRuleId")] public double SimulationParamRuleId { get; set; }

        [Column("ParamName")] public double ParamName { get; set; }

        [Column("ParamValue")] public double ParamValue { get; set; }

        public ICollection<SimulationParamRule> SimulationParamRule { get; set; }

        public ICollection<Strategy> Strategy { get; set; }
    }
}
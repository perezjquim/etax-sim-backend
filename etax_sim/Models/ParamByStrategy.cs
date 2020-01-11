using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("ParamByStrategy")]
    public class ParamByStrategy
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("StrategyId")] public int StrategyId { get; set; }

        //[Column("SimulationParamRuleId")] public int SimulationParamRuleId { get; set; }

        [Column("ParamName")] public String ParamName { get; set; }

        //[Column("ParamValue")] public double ParamValue { get; set; }

        [Column("IsInput")] public bool IsInput { get; set; }

        public StrategyParamRule StrategyParamRule { get; set; }

        public Strategy Strategy { get; set; }
    }
}
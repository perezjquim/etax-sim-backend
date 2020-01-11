using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("RuleAllowedValues")]
    public class RuleAllowedValues
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("Value")] public string Value { get; set; }
        public StrategyParamRule StrategyParamRule { get; set; }
    }
}
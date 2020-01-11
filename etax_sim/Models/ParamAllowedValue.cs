using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("ParamAllowedValues")]
    public class ParamAllowedValue
    {
        [Key] [Column("ID")] public int Id { get; set; }
        public ParamByStrategy ParamByStrategy { get; set; }
        public RuleAllowedValue RuleAllowedValue { get; set; }
    }
}
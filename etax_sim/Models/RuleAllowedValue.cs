using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("RuleAllowedValues")]
    public class RuleAllowedValue
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("Value")] public string Value { get; set; }
        public ICollection<ParamAllowedValue> ParamAllowedValue { get; set; }
    }
}
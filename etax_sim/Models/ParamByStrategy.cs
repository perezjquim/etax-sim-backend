using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("ParamByStrategy")]
    public class ParamByStrategy
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("StrategyId")] public int StrategyId { get; set; }

        [Column("ParamName")] public string ParamName { get; set; }

        [Column("IsInput")] public bool IsInput { get; set; }

        public StrategyParamRule StrategyParamRule { get; set; }

        public Strategy Strategy { get; set; }

        public ICollection<ParamAllowedValue> ParamAllowedValue { get; set; }
    }
}
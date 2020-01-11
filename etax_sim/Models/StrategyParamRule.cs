using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("StrategyParamRule")]
    public class StrategyParamRule
    {
        [Key] [Column("ID")] public int Id { get; set; }

        //[Column("ParamName")] public String ParamName { get; set; }

        [Column("MinValue")] public double? MinValue { get; set; }

        [Column("MaxValue")] public double? MaxValue { get; set; }

    }
}
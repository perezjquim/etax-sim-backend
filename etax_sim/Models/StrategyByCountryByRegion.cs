using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("StrategyByCountryByRegion")]
    public class StrategyByCountryByRegion
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("CountryId")] public int CountryId { get; set; }

        [Column("RegionId")] public int RegionId { get; set; }

        [Column("StrategyId")] public int StrategyId { get; set; }

        [Column("StrategyByCountryId")] public int StrategyByCountryId { get; set; }

        public Country Country { get; set; }

        public Region Region { get; set; }

        [ForeignKey(nameof(StrategyId))] public Strategy Strategy { get; set; }

        public StrategyByCountry StrategyByCountry { get; set; }
    }
}
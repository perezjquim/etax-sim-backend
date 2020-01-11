using System;
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

        //[Column("ParentStrategyId")] public int ParentStrategyId { get; set; }

        //[Column("Description")] public String Description { get; set; }

        public Country Country { get; set; }

        public Region Region { get; set; }

        [ForeignKey(nameof(StrategyId))]
        public Strategy Strategy { get; set; }

        //[ForeignKey(nameof(ParentStrategyId))]
       // public Strategy ParentStrategy { get; set; }

        //[ForeignKey(nameof(CountryId))]
       public StrategyByCountry StrategyByCountry { get; set; }
    }
}
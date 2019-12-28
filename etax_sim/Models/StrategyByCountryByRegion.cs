using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("StrategyByCountryByRegion")]
    public class StrategyByCountryByRegion
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("CountryId")] public String CountryId { get; set; }

        [Column("RegionId")] public int RegionId { get; set; }

        [Column("StrategyId")] public int StrategyId { get; set; }

        [Column("Description")] public double Description { get; set; }

        public Country Country { get; set; }

        public Region Region { get; set; }

        public Strategy Strategy { get; set; }
    }
}
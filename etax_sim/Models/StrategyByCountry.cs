using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("StrategyByCountry")]
    public class StrategyByCountry
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("CountryId")] public String CountryId { get; set; }

        [Column("StrategyId")] public String StrategyId { get; set; }

        [Column("Description")] public double Description { get; set; }

        public ICollection<Country> Country { get; set; }

        public ICollection<Strategy> Strategy { get; set; }
    }
}
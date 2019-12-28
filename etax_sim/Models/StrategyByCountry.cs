using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("StrategyByCountry")]
    public class StrategyByCountry
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("CountryId")] public String CountryId { get; set; }

        [Column("StrategyId")] public String StrategyId { get; set; }

        [Column("Description")] public double Description { get; set; }

        public Country Country { get; set; }

        public Strategy Strategy { get; set; }
    }
}
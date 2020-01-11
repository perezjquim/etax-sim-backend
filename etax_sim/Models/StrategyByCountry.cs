using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("StrategyByCountry")]
    public class StrategyByCountry
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("CountryId")] public int CountryId { get; set; }

        [Column("StrategyId")] public int StrategyId { get; set; }

        //[Column("Description")] public String Description { get; set; }

        public Country Country { get; set; }

        public Strategy Strategy { get; set; }

        public ICollection<StrategyByCountryByRegion> StrategyByCountryByRegion { get; set; }
    }
}
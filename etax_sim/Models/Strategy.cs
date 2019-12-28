using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("Strategy")]
    public class Strategy
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("Name")] public String Name { get; set; }

    }
}
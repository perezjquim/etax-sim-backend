using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("Company")]
    public class Company
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("Name")] public string Name { get; set; }

        [Column("Description")] public string Description { get; set; }

        [Column("IsActive")] public bool IsActive { get; set; }

        [Column("CreatedAt")] public DateTime CreatedAt { get; set; }

        [Column("ModifiedAt")] public DateTime ModifiedAt { get; set; }

        [Column("SectorId")] public int SectorId { get; set; }
        public Sector Sector { get; set; }

        [Column("RegionId")] public int RegionId { get; set; }
        public Region Region { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
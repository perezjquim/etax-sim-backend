using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTaxSim.Models
{
    [Table("Role")]
    public class Role
    {
        [Key] [Column("ID")] public int Id { get; set; }

        [Column("Name")] public string Name { get; set; }

        [Column("Description")] public string Description { get; set; }

        [Column("IsActive")] public bool IsActive { get; set; }

        [Column("CreatedAt")] public DateTime CreatedAt { get; set; }

        [Column("ModifiedAt")] public DateTime ModifiedAt { get; set; }

        [Column("CompanyId")] public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
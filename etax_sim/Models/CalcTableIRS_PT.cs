using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
    [Table("__CALC_IRS_PT__")]
    public class CalcTableIRS_PT
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        // TODO
    }
}
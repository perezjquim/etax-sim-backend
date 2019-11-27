using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace etax_sim.Models
{
        [Table("__CALC_PT_IRS_PENS__")]
    public class CalcPT_IRSPens
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        // 0 - não casado
        // 1 - casado, único titular
        // 2 - casado, 2 titulares
        [Column("NumberOfMarriageHolders")]        
        public int NumberOfMarriageHolders { get; set; }

        [Column("IsHandicapped")]
        public bool IsHandicapped { get; set; }

        [Column("IsArmedForces")]
        public bool IsArmedForces { get; set; }

        // 0 no caso de ser até o infinito
        [Column("MaxSalary")]
        public double MaxSalary { get; set; }

        [Column("IRSTax")]
        public double IRSTax { get; set; }        
    }
}
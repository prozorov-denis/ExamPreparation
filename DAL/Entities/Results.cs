namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Results
    {
        [Key]
        public int Results_ID { get; set; }

        public int Tasks_ID { get; set; }

        public int Students_ID { get; set; }

        public bool? Solved { get; set; }

        public virtual Students Students { get; set; }

        public virtual Tasks Tasks { get; set; }
    }
}

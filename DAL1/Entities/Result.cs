namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        [Key]
        public int Results_ID { get; set; }

        public int Tasks_ID { get; set; }

        public int Students_ID { get; set; }

        public bool? Solved { get; set; }

        [StringLength(10)]
        public string Solution_Text { get; set; }

        public virtual Student Student { get; set; }

        public virtual Task Task { get; set; }
    }
}
